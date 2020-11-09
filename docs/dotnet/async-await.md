# Ошибки при работе с async/await

## Лишний async/await

Использование ключевых слов async/await приводит к неявному выделению памяти под [конечный автомат](https://t.me/NetDeveloperDiary/249), который отвечает за организацию асинхронных вызовов. Когда ожидаемое выражение является единственным или последним оператором в функции, его можно пропустить. Однако с этим есть несколько проблем, о которых вам следует [знать](https://t.me/NetDeveloperDiary/680).

```
❌ Неверно
async Task DoSomethingAsync(){
  await Task.Yield();
}

✅ Верно
Task DoSomethingAsync() {
  return Task.Yield();
}
```

## Вызов синхронного метода внутри асинхронного метода

Если мы используем асинхронный код, мы всегда должны использовать асинхронные методы, если они существуют. Многие API предлагают асинхронные аналоги своих хорошо известных синхронных методов.

```
❌ Неверно
async Task DoAsync(Stream file, byte[] buffer) {
  file.Read(buffer, 0, 10);
}

✅ Верно
async Task DoAsync(Stream file, byte[] buffer) {
  await file.ReadAsync(buffer, 0, 10);
}
```

## Использование async void

Есть две причины, по которым async void вреден:

- Вызывающий код не может ожидать метод async void.
- Невозможно обработать исключение, вызванное этим методом. Если возникает исключение, ваш процесс падает!
  Вы всегда должны использовать async Task вместо async void, если только это не обработчик событий, но тогда вы должны гарантировать себе, что метод выбросит исключения.

```
❌ Неверно
async void DoSomethingAsync() {
  await Task.Yield();
}

✅ Верно
async Task DoSomethingAsync() {
  await Task.Yield();
}
```

## Неподдерживаемые асинхронные делегаты

Если передать асинхронную лямбда-функцию в качестве аргумента типа Action, компилятор сгенерирует метод async void, недостатки которого были описаны выше. Есть два решения этой проблемы:

- изменить тип параметра с Action на Func<Task>,
- реализовать этот делегат синхронно.
  Стоит отметить, что некоторые API-интерфейсы уже предоставляют аналоги своих методов, которые принимают Func<Task>.

```
void DoSomething() {
  Callback(async() => {
    await Task.Yield();
  });
}

❌ Неверно
void Callback(Action action){…}

✅ Верно
void Callback(Func<Task> action){…}
```

## Не ожидать Task в выражении using

System.Threading.Tasks.Task реализует интерфейс IDisposable. Вызов метода, возвращающего Task, непосредственно в выражении using приводит к удалению задачи в конце блока using, что никогда не является ожидаемым поведением.

```
❌ Неверно
using (CreateDisposableAsync()) {
 …
}

✅ Верно
using (await CreateDisposableAsync()) {
 …
}
```

## Не ожидать Task в блоке using

Если мы пропустим ключевое слово await для асинхронной операции внутри блока using, то объект может быть удалён до завершения асинхронного вызова. Это приведёт к неправильному поведению и очень часто заканчивается исключением времени выполнения, сообщающим о том, что мы пытаемся работать с уже удалённым объектом.

```
❌ Неверно
private Task<int> DoSomething() {
  using (var service = CreateService()) {
    return service.GetAsync();
  }
}

✅ Верно
private async Task<int> DoSomething() {
  using (var service = CreateService()) {
    return await service.GetAsync();
  }
}
```

## Не ожидать результата асинхронного метода

Отсутствие ключевого слова await перед асинхронной операцией приведет к завершению метода до завершения данной асинхронной операции. Метод будет вести себя непредсказуемо, и результат будет отличаться от ожиданий. Ещё хуже, если неожидаемое выражение выбросит исключение. Оно остается незамеченным и не вызовет сбоя процесса, что ещё больше затруднит его обнаружение. Вы всегда должны ожидать асинхронное выражение или присвоить возвращаемую задачу переменной и убедиться, что в итоге она где-то ожидается.

```
❌ Неверно
async Task DoSomethingAsync() {
  await DoSomethingAsync1();
  DoSomethingAsync2();
  await DoSomethingAsync3();
}

✅ Верно
async Task DoSomethingAsync() {
  await DoSomethingAsync1();
  await DoSomethingAsync2();
  await DoSomethingAsync3();
}
```

## Синхронные ожидания

Если вы хотите ожидать асинхронное выражение в синхронном методе, вы должны переписать всю цепочку вызовов на асинхронную. Кажется, что более легкое решение - вызвать Wait или Result для возвращаемой задачи. Но это будет стоить вам заблокированного потока и может привести к взаимной блокировке. Сделайте всю цепочку асинхронной. В консольном приложении допустим асинхронный метод Main, в контроллерах ASP.NET – асинхронные методы действия.

```
❌ Неверно
void DoSomething() {
  Thread.Sleep(1);
  Task.Delay(2).Wait();
  var result1 = GetAsync().Result;
  var result2 = GetAsync().GetAwaiter().
    GetResult();
  var unAwaitedResult3 = GetAsync();
  var result3 = unAwaitedResult3.Result;
}

✅ Верно
async Task DoSomething() {
  await Task.Delay(1);
  await Task.Delay(2);
  var result1 = await GetAsync();
  var result2 = await GetAsync();
}
```

## Отсутствие ConfigureAwait(bool)

По умолчанию, когда мы ожидаем асинхронную операцию, продолжение планируется с использованием захваченного SynchronizationContext или TaskScheduler. Это приводит к дополнительным затратам и может привести к взаимной блокировке, особенно в WindowsForms, WPF и старых приложениях ASP.NET. Вызывая ConfigureAwait(false), мы гарантируем, что текущий контекст игнорируется при вызове продолжения. Подробнее о ConfigureAwait в серии постов с тегом #AsyncAwaitFAQ

```
❌ Неверно
async Task DoSomethingAsync() {
  await DoSomethingElse();
}

✅ Верно
async Task DoSomethingAsync() {
  await DoSomethingElse().
    ConfigureAwait(false);
}
```

## Возврат null из метода, возвращающего Task

Возврат null значения из синхронного метода типа Task/Task<> приводит к исключению NullReferenceException, если кто-то ожидает этот метод. Чтобы этого избежать, всегда возвращайте результат этого метода с помощью помощников Task.CompletedTask или Task.FromResult<T>(null).

```
❌ Неверно
Task DoAsync() {
  return null;
}
Task<object> GetSomethingAsync() {
  return null;
}
Task<HttpResponseMessage>
    TryGetAsync(HttpClient httpClient) {
  return httpClient?.
    GetAsync("/some/endpoint");
}

✅ Верно
Task DoAsync() {
  return Task.CompletedTask;
}
Task<object> GetSomethingAsync() {
  return Task.FromResult<object>(null);
}
Task<HttpResponseMessage>
   TryGetAsync(HttpClient httpClient) {
  return httpClient?.
      GetAsync("/some/endpoint") ??
    Task.FromResult(default(
      HttpResponseMessage));
}
```

## Передача токена отмены

Если вы забудете передать токен отмены, это может привести к большим проблемам. Запущенная длительная операция без токена отмены может заблокировать действие по остановке приложения или привести к нехватке потоков при большом количестве отменённых веб-запросов. Чтобы избежать этого, всегда создавайте и передавайте токен отмены методам, которые его принимают, даже если это необязательный параметр.

```
❌ Неверно
public async Task<string>
   GetSomething(HttpClient http) {
  var response = await
    http.GetAsync(new Uri("/endpoint/"));
  return await
    response.Content.ReadAsStringAsync();
}

✅ Верно
public async Task<string>
  GetSomething(HttpClient http,
    CancellationToken ct) {
  var response = await
    http.GetAsync(new Uri("/endpoint/"),
      ct);
  return await
    response.Content.ReadAsStringAsync();
}
```

## Использование токена отмены с IAsyncEnumerable

Эта ошибка похожа на предыдущую, но относится исключительно к IAsyncEnumerable и её довольно легко допустить. Это может быть неочевидно, но передача токена отмены в асинхронный перечислитель выполняется путем вызова метода WithCancellation().

```
❌ Неверно
async Task Iterate(
    IAsyncEnumerable<string> e) {
  await foreach (var item in e) {
   …
  }
}

✅ Верно
async Task Iterate(
    IAsyncEnumerable<string> e,
    CancellationToken ct) {
  await foreach (var item in
    e.WithCancellation(ct))
  {
   …
  }
}
```

## Имена асинхронных методов должны заканчиваться на Async

И наоборот, имена синхронных методов не должны заканчиваться на Async. Так обычно происходит при невнимательном рефакторинге. Это не строгое обязательство и не ошибка. Вообще, это соглашение об именовании имеет смысл только тогда, когда класс предоставляет как синхронные, так и асинхронные версии метода.

```
❌ Неверно
async Task DoSomething() {
  await Task.Yield();
}

✅ Верно
async Task DoSomethingAsync() {
  await Task.Yield();
}
```

## Злоупотребление Task.Run в простых случаях

Для предварительно вычисленных или легко вычисляемых результатов нет необходимости вызывать Task.Run, который поставит задачу в очередь пула потоков, а задача немедленно завершится. Вместо этого используйте Task.FromResult, чтобы создать задачу, обёртывающую уже вычисленный результат.

```
❌ Неверно
public Task<int> AddAsync(int a, int b) {
  return Task.Run(() => a + b);
}

✅ Верно
public Task<int> AddAsync(int a, int b) {
  return Task.FromResult(a + b);
}
```

## Await лучше, чем ContinueWith

Хотя методы продолжений по-прежнему можно использовать, обычно рекомендуется использовать async/await вместо ContinueWith. Кроме того, надо отметить, что ContinueWith не захватывает SynchronizationContext и поэтому семантически отличается от async/await.

```
❌ Неверно
public Task<int> DoSomethingAsync() {
  return CallDependencyAsync()
    .ContinueWith(task => {
      return task.Result + 1;
    });
}

✅ Верно
public async Task<int> DoSomethingAsync() {
  var result =
    await CallDependencyAsync();
  return result + 1;
}
```

## Синхронизация асинхронного кода в конструкторах

Конструкторы синхронны. Если вам нужно инициализировать некоторую логику, которая может быть асинхронной, использование Task.Result для синхронизации в конструкторе может привести к истощению пула потоков и взаимным блокировкам. Лучше использовать статическую фабрику.

```
public interface IRemoteConnFactory {
  Task<IRemoteConn> ConnectAsync();
}
public interface IRemoteConn { … }

❌ Неверно
public class Service : IService {
  private readonly IRemoteConn _conn;

  public Service(IRemoteConnFactory cf) {
    _conn = cf.ConnectAsync().Result;
  }
}

✅ Верно
public class Service : IService {
  private readonly IRemoteConn _conn;

  private Service(IRemoteConn conn) {
    _conn = conn;
  }

  public static async Task<Service>
      CreateAsync(IRemoteConnFactory cf)
  {
    return new Service(
      await cf.ConnectAsync());
  }
}
…
var cf = new ConnFactory();
var srv = await Service.CreateAsync(cf);
```
