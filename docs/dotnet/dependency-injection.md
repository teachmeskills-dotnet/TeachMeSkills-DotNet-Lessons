# Внедрение зависимостей в ASP.NET Core

ASP.NET Core активно использует внедрение зависимостей. Теорию я описывал в этом [посте](https://t.me/NetDeveloperDiary/579), а тут будет только практика.
По умолчанию в приложениях используется контейнер внедрения зависимостей (контейнер DI) от Microsoft, который несколько ограничен в функционале, по сравнению с другими, но подходит в большинстве случаев. Он находится в отдельной библиотеке в пространстве имён Microsoft.Extensions.DependencyInjection. В проект он обычно включается в составе метапакета Microsoft.AspNetCore.All.

Необходимые для внедрения интерфейсы и классы (также называемые сервисами) регистрируются в коллекции типа IServiceCollection. Чаще всего это происходит в методе ConfigureServices класса Startup. Во время работы приложения контейнер DI отвечает за обнаружение необходимого сервиса и создание его экземпляра с нужным сроком жизни.

```
public void ConfigureServices(IServiceCollection services) { … }
```

Параметр services на момент вызова метода будет [инициализирован хостом](https://t.me/NetDeveloperDiary/630). В отличие от регистрации промежуточного ПО в методе Configure, порядок регистрации сервисов чаще всего не имеет значения.

## Что регистрировать в сервисах?

В первую очередь – зависимости. Просмотрите свой код и найдите использования ключевого слова new. Если ваш класс A создаёт экземпляр класса B, вызывает его методы и использует результат их работы, то класс A зависит от класса B.

```
class A {
  public MethodA() {
    var b = new B();
    b.MethodB();
  }
}
```

Класс B - кандидат на регистрацию в сервисах. В общем случае это делается в 3 этапа:

1. Выделяем интерфейс из класса B:

```
interface InterfaceB {
  void MethodB();
}
class B : InterfaceB {…}
```

2. Добавляем интерфейс в параметры конструктора класса A:

```
class A {
  private readonly InterfaceB _b;

  public A(InterfaceB b) {
    _b = b;
  }
}
```

3. Регистрируем реализацию интерфейса в контейнере DI:

```
services.AddTransient<InterfaceB, B>();
```

Однако, если, например, метод действия контроллера использует new для создания объекта модели и передаёт её в представление, то модель в этом случае используется для передачи данных между слоями приложения, и не является зависимостью.

В коде приложения могут появиться цепочки зависимостей, когда класс A зависит от класса B, а тот зависит от C. Контейнер DI способен разрешать эти зависимости и находить соответствующие сервисы автоматически.

## Время жизни сервисов

Контейнер DI отвечает за создание и уничтожение экземпляров сервисов. Доступно 3 варианта регистрации:

1. **Transient** – новый экземпляр сервиса создаётся каждый раз, когда он требуется. Каждый класс, зависящий от такого сервиса, получит отдельный экземпляр:

```
services.AddTransient<IEmailSender, EmailSender>();
```

- самый простой в работе: если срок жизни сервиса сложно определить, Transient сервис чаще всего будет наиболее подходящим;
- не требует потокобезопасности, т.к. не подходит для сохранения состояния;
- потенциально может неэффективно использовать память и вести к созданию и уничтожению множества объектов.

2. **Singleton** – экземпляр создаётся на всё время работы приложения. Один и тот же экземпляр сервиса будет использоваться во всех зависящих от него классах всё время:

```
services.AddSingleton<ILoggerFactory, LoggerFactory>();
```

- изменение состояния сервиса (если оно допускается) должно быть потокобезопасно;
- обычно более эффективен, чем Transient, т.к. создаётся только один объект, поэтому подходит для дорогих в создании объектов,
- может приводить к утечкам памяти при регистрации больших редко используемых объектов;
- подходит для объектов с общими функциями, не сохраняющими состояние (например, логгер).

3. **Scoped** – экземпляр сервиса создаётся на время обработки запроса к приложению. Зависимые объекты в течение обработки одного запроса получат один и тот же экземпляр. Например, в EntityFramework класс DbContext регистрируется как Scoped:

```
services.AddScoped<IOrderService, OrderService>();
```

## Избегайте захвата сервисов

Сервис не должен зависеть от другого сервиса с меньшим временем жизни! Если Singleton-сервис зависит от Transient- или Scoped-сервиса, то последний может быть захвачен и не будет уничтожен в течение всего времени жизни приложения. Это может приводить как к утечкам памяти, так и к совместному использованию непотокобезопасного кода из Transient-сервисов.
Начиная с ASP.NET Core 2.0 по умолчанию включена валидация времени жизни сервисов (ValidateScopes). Она приводит к ошибке времени выполнения при старте приложения, если будет обнаружен захват сервисов. Однако, учтите, что эта функция отключена в продакшн, и её не рекомендуется включать вне среды разработки.

## Регистрация открытых обобщённых типов

Иногда требуется зарегистрировать реализацию обобщённого интерфейса. Например, ILogger<T>. В этом случае используется необобщённый метод Add… и typeof:

```
services.AddSingleton(typeof(ILogger<>), typeof(MyLogger<>));
```

Если параметров типа больше одного, внутрь угловых скобок добавляются запятые(например, typeof(ISomeInterface<,>)).

## Дескрипторы сервисов

Дескрипторы сервисов (класс ServiceDescriptor) содержат информацию о регистрируемых сервисах и используются внутри контейнера DI.

```
var sd = new ServiceDescriptor(typeof(IOrderService),
  typeof(OrderService), ServiceLifetime.Scoped);
services.Add(sd);
```

Чаще всего создание дескриптора скрыто в методах расширения, описанных выше, и создание его вручную не требуется.

## Регистрация нескольких сервисов

Если в методе ConfigureServices используется несколько регистраций для одного интерфейса, то последняя из них имеет приоритет.

```
services.AddTransient<IMessageSender, EmailSender>();
services.AddTransient<IMessageSender, SMSSender>();
```

Здесь в приложении будет использован SMSSender.

Чтобы избежать случайной «перезаписи» зарегистрированных сервисов, можно использовать соответствующий TryAdd… метод (например, TryAddTransient). Тогда реализация будет добавлена, только если она ещё не была зарегистрирована ранее.
Важно отметить, что без использования TryAdd… зарегистрированы будут оба сервиса, но лишь последняя реализация будет использована при обнаружении сервиса.

Иногда нужно явно перезаписать предыдущую регистрацию. Тогда используется метод Replace, принимающий дескриптор сервиса:

```
services.Replace(
  new ServiceDescriptor(typeof(IMessageSender),
    typeof(SMSSender), ServiceLifetime.Transient)
  );
```

Чтобы удалить все регистрации сервисов для определённого интерфейса, используется метод RemoveAll:

```
services.RemoveAll<IMessageSender>();
```

Использовать эти методы придётся редко. Например, чтобы предоставить свою реализацию одного из сервисов сторонней библиотеки.

Зачем же контейнер DI регистрирует несколько реализаций? Это может пригодиться, когда вам нужно, например, зарегистрировать несколько отправителей сообщений, валидаторов данных или бизнес-правил, которые должны будут применены одно за другим. В этом случае в конструктор зависимого класса внедряется коллекция сервисов:

```
public class Notifier {
  IEnumerable<IMessageSender> _senders;

  public Notifier(
     IEnumerable<IMessageSender> senders) {
    _senders = senders;
  }
  public void SendMessage() {
    foreach (var s in _senders) {
      // обработка каждого отправителя
    }
  }
}
```

Таким образом, если мы хотим добавить, скажем, отправку через пуш-уведомления, нам нужно только добавить реализацию и зарегистрировать её в контейнере DI. Это одно из ограничений стандартного контейнера. Другие, более продвинутые, позволяют автоматически сканировать сборку и добавлять все реализации интерфейса.

При регистрации нескольких реализаций может быть нежелательно регистрировать одинаковые реализации, что обычными методами не проверяется. В нашем случае, если случайно зарегистрировать SMSSender дважды, сообщение по смс будет отправлено 2 раза. Тогда можно использовать метод TryAddEnumerable, принимающий коллекцию дескрипторов сервисов:

```
services.TryAddEnumerable(new[]
{
  new ServiceDescriptor(typeof(IMessageSender),
    typeof(EmailSender), ServiceLifetime.Transient),
  new ServiceDescriptor(typeof(IMessageSender),
    typeof(SMSSender), ServiceLifetime.Transient),
  new ServiceDescriptor(typeof(IMessageSender),
    typeof(SMSSender), ServiceLifetime.Transient)
});
```

В этом случае будет зарегистрирована только одна реализация SMSSender.

## Чистый код

В более-менее большом приложении метод ConfigureServices разрастается довольно быстро, и в нём становится сложно ориентироваться. В этом случае поможет создание методов расширения для IServiceCollection. По соглашению имена таких методов начинаются с Add:

```
public static IServiceCollection AddCoreServices(
  this IServiceCollection services) {
   services.AddScoped<…>();
   //…
   return services;
}
```

Важно возвращать из метода набор сервисов, чтобы эти методы расширения можно было объединять в цепочки. Тогда метод ConfigureServices будет выглядеть компактнее и понятнее:

```
public void ConfigureServices(
    IServiceCollection services) {
  services.AddCoreServices()
    .AddDatabaseServices()
    .AddCaching()
   …
}
```

Для многих внутренних сервисов ASP.NET Core уже добавлены методы расширения, например, AddMvc(), AddIdentity(), AddDbContext() и т.п.

## Механизмы обнаружения сервисов

В ASP.NET Core используется два основных механизма обнаружения. За обнаружение сервисов, зарегистрированных в контейнере DI, отвечает провайдер сервисов, реализующий IServiceProvider. Также используются статические методы класса ActivatorUtilities. В этом случае можно создавать сервисы, не зарегистрированные в контейнере DI, через конструктор. Конструктору можно передавать параметры либо напрямую, либо указать сервисы, зарегистрированные в конструкторе DI, и они будут обнаружены через провайдер сервисов. В ASP.NET Core таким образом создаются внутренние компоненты, вроде контроллеров, тег-хелперов, фильтров и т.п.

Другие типы внедрения зависимостей

1. **В методы действия контроллеров**
   В ASP.NET Core помимо обычного внедрения зависимостей через конструктор доступно внедрение в методы действия контроллеров. Для этого используется атрибут параметра FromServices:

```
public async Task<IActionResult> Update([FromServices] IMessageSender sender) {…}
```

Это полезно, если сервис используется только в одном методе действия контроллера, и его не нужно создавать при вызовах других методов действия, как было бы при использовании внедрения через конструктор.

2. **В промежуточное ПО (Middleware)**
   Проблема внедрения зависимостей в конструктор промежуточного ПО может быть при попытке внедрения Scoped сервиса, т.к. промежуточное ПО создаётся на всё время жизни приложения. В результате возникает ошибка захвата сервисов, описанная в предыдущем посте. В этом случае доступно внедрение зависимости прямо в метод Invoke/InvokeAsync промежуточного ПО. В конструктор промежуточного ПО можно внедрять только Singleton-сервисы.

3. **В представления**
   Внедрять зависимости прямо в представления требуется редко, и это не рекомендуется, т.к. обычно это помещает бизнес логику в слой представления, где ей не место. Одним из сценариев использования может быть получение набора опций для выпадающего списка. В представлении используется ключевое слово inject

```
@inject IOptionsProvider options
```