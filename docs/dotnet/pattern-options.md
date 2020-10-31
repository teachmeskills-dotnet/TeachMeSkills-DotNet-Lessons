# Паттерн Options

Паттерн Options помогает связывать конфигурацию приложения со строго типизированными классами. Преимущество этого подхода перед получением каждого свойства конфигурации по отдельности (помимо сокращения объёма кода) в том, что есть возможность группировать связанные свойства, а также производить валидацию свойств.

```
"Position": {
  "Title": "Editor",
  "Name": "Joe Smith"
}

public class PositionOptions {
  public const string Position = "Position";

  public string Title { get; set; }
  public string Name { get; set; }
}
```

Заметьте, что используется статическая переменная Position с путём к секции конфигурации (в данном случае "Position"), чтобы избежать опечаток (см. ниже). Получить значение в коде можно через внедрение зависимости IConfiguration:
private readonly IConfiguration \_configuration;
Далее либо через вызов метода ConfigurationBinder.Bind:

```
var positionOptions = new PositionOptions(); _configuration.GetSection(PositionOptions.Position)
  .Bind(positionOptions);
либо через вызов метода ConfigurationBinder.Get<T>:
positionOptions =
  _configuration.GetSection(PositionOptions.Position)
    .Get<PositionOptions>();
```

Кроме того, можно добавить регистрацию параметров в сервисы:

```
public void ConfigureServices(IServiceCollection services) {
  services.Configure<PositionOptions>(
    Configuration.GetSection(
      PositionOptions.Position));
  // либо
  services.AddOptions<PositionOptions>()
    .Bind(Configuration.GetSection(
      PositionOptions.Position));
  …
}
```

И использовать через внедрение зависимости:

```
private readonly PositionOptions _options;
public TestModel(IOptions<PositionOptions> options) {
  _options = options.Value;
}
```

## Обновление значений

Что если нам нужно обновлять значения параметров во время работы приложения? IOptions<T> устанавливается как Singleton в контейнере DI. Значения параметров устанавливаются при первом обращении к ним, и не могут быть изменены без рестарта. Именованные параметры (о них далее) не поддерживаются.

В этом случае вместо IOptions<T> можно использовать один из двух вариантов:

1. **IOptionsSnapshot<T>**
   Поддерживает перезагрузку параметров и именованные параметры. Регистрируется как Scoped сервис. Поэтому обновлённые значения параметров будут доступны при следующем запросе к приложению. Однако из-за регистрации как Scoped, IOptionsSnapshot<T> не может быть внедрён в Singleton сервисы.

2. **IOptionsMonitor<T>**
   Поддерживает перезагрузку параметров и именованные параметры. Регистрируется как Singleton сервис. Значения параметров доступны через options.CurrentValue (в отличие от Value в предыдущих случаях). Кроме того, поддерживается метод OnChange, в котором регистрируется делегат, обновляющий значения в коде при изменении конфигурации, а также, например, делающий запись в лог.

## Извлечение в интерфейс

Чтобы не использовать внедрения вроде IOptions<T> или IOptionsSnapshot<T> в классах приложения, можно выделить параметры в интерфейс

```
public class PositionOptions : IPositionOptions {
  public const string Position = "Position";

  public string Title { get; set; }
  public string Name { get; set; }
}

public interface IPositionOptions {
  string Title { get; }
  string Name { get; }
}
```

Затем зарегистрируем интерфейс в сервисах, используя фабрику:

```
services.Configure<PositionOptions>(
  Configuration.GetSection("Position"));
services.AddSingleton<IPositionOptions>(
  sp => sp.GetRequiredService<
    IOptions<PositionOptions>>().Value);
```

И используем готовый интерфейс:

```
public TestModel(IPositionOptions options) {
  _options = options;
}
```

## Именованные параметры

Именованные параметры полезны, когда несколько разделов конфигурации привязаны к одним и тем же свойствам. Например:

```
"ContactUs": {
  "Manager": {
    "Name": "Joe Smith",
    "Phone": "555-01-01"
  },
  "CEO": {
    "Name": "Jane Smith",
    "Phone": "555-02-02"
  }
}

public class ContactSettings {
  public string Name { get; set; }
  public string Phone { get; set; }
}
```

Тогда можно использовать перегруженную версию метода Configure, принимающую строковое имя:

```
services.
  Configure<ContactSettings>("Manager",
    Configuration.GetSection(
      "ContactUs:Manager"));
services.Configure<ContactSettings>("CEO",
  Configuration.GetSection("ContactUs:CEO"));
```

Получить значения параметров из сервиса можно, передав имя набора в метод Get:

```
private readonly ContactSettings _manager;
private readonly ContactSettings _ceo;

public TestNamed(
    IOptionsSnapshot<ContactSettings> options) {
  _manager = options.Get("Manager");
  _ceo = options.Get("CEO");
}
```

## Валидация

Валидацию параметров можно осуществлять несколькими способами:

1. **Аннотации**
   Аналогично валидации модели (https://t.me/NetDeveloperDiary/452), можно использовать атрибуты из System.ComponentModel.DataAnnotations:

```
public class PositionOptions {
  public string Title { get; set; }
  [Required]
  public string Name { get; set; }
}
```

При этом в регистрации используется метод AddOptions, позволяющий добавить валидацию в цепочку:

```
services.AddOptions<PositionOptions>()
  .Bind(Configuration
         .GetSection("Position"))
  .ValidateDataAnnotations();
```

2. **Метод Validate**
   Можно реализовать более сложную, чем аннотации, логику валидации при регистрации:

```
services.AddOptions<PositionOptions>()
  .Bind(Configuration
         .GetSection("Position"))
  .Validate(с => { … });
```

Метод должен возвращать результат валидации в виде булева значения.

3. **IValidateOption<T>**
   При этом подходе создаётся класс валидации, реализующий IValidateOption<T>, например:

```
public class PositionOptionsValidation :
    IValidateOption<PositionOptions> {
  …
}
```

Класс должен реализовать метод Validate интерфейса. Преимущество этого подхода в том, что для валидации можно использовать другие сервисы через DI. Регистрируется класс как Singleton после регистрации параметров:

```
services.Configure<MyConfigOptions>(
  Configuration.GetSection("Position"));
services.TryAddEnumerable(
  ServiceDescriptor
    .Singleton<
      IValidateOptions<PositionOptions>,
      PositionOptionsValidation>());
```

Метод TryAddEnumerable позволяет регистрировать в DI коллекцию реализаций для интерфейса, поскольку у нас может быть несколько классов валидаторов.

Остаётся одна проблема в том, что валидация происходит "лениво", то есть только при обращении к параметрам (только на той странице, где они используются), что может приводить к сложным в обнаружении проблемам. См. текущее положение дел (https://github.com/dotnet/runtime/issues/36391).

В этом случае одним из вариантов может быть создание фонового сервиса, который будет запускаться вместе с приложением и проверять все параметры. Кроме того, ему можно передать реализацию IHostApplicationLifetime, позволяющую управлять основным приложением:

```
public class ValidateOptionsService : IHostedService {
  public ValidateOptionsService(
      IHostApplicationLifetime appLifetime,
      IOptions<PositionOptions> posOptions,
      //другие параметры…) {
    _appLifetime = appLifetime;
    _posOptions = posOptions;
    …
  }
}
```

IHostedService предполагает реализацию двух методов, возвращающих Task: StartAsync и StopAsync. В последнем можно ничего не делать, просто вернуть Task.CompletedTask.
А в StartAsync добавляется код проверки параметров. Как вариант, при возникновении ошибок валидации можно останавливать приложение:

```
public Task StartAsync(CancellationToken ct) {
  try {
    //доступ к параметру приводит к валидации
    _ = _posOptions.Value;
  }
  catch (OptionsValidationException ex) {
    // останавливаем приложение
    _appLifetime.StopApplication();
  }

  return Task.CompletedTask;
}
```
