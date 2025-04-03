# Task - Working with Asynchronous Programming

- Build a Console Application that mimics the mulitple api calls parallely using an `async` anf `await` type of asynchronous programming. To make the difference between each api calls use `Task.Delay(3000).wait()` to delay the respone.

## Asynchronous Programming

- Asynchronous programming is a way to run tasks without blocking the main thread. Instead of making the program wait for a long-running task to complete (like downloading a file or making an HTTP request), it allows the program to keep doing other things.

## Async Keyword

- Used to define an asynchronous method.
- Makes a method capable of using `await` inside it.
- Does not run the method on a separate thread.
- Returns a `Task` or `Task<T>`

## Await Keyword

- Pauses the execution of the method until the awaited task is complete.
- Allows other tasks to run during the wait.
- Must be used inside an async method.

## Async and Await Example

1. Main Method Signature

```
static async Task Main(string[] args)
{
    try
    {
        Console.WriteLine("Fetching data from multiple URLs asynchronously...");
        var userTasks = fetchUserDataAsync("https://jsonplaceholder.typicode.com/users/1");
        var postTasks = fetchPostDataAsync("https://jsonplaceholder.typicode.com/posts/1");
        var commentTasks = fetchCommentDataAsync("https://jsonplaceholder.typicode.com/comments/1");

        await Task.WhenAll(userTasks, postTasks, commentTasks);
        Console.WriteLine("Data fetching Completed!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
```

- Declares the entry point of the program.
- Uses `async` to enable asynchronous calls.
- Returns a `Task` to support asynchronous execution.
- Handles any exceptions that may occur during the asynchronous calls.

```
var userTasks = fetchUserDataAsync("https://jsonplaceholder.typicode.com/users/1");
var postTasks = fetchPostDataAsync("https://jsonplaceholder.typicode.com/posts/1");
var commentTasks = fetchCommentDataAsync("https://jsonplaceholder.typicode.com/comments/1");
```

- Calls three asynchronous methods without using await directly.
- Assigns each method call to a Task variable.

```
await Task.WhenAll(userTasks, postTasks, commentTasks);
```

- Waits for all tasks to complete.
- The `await` keyword ensures that the program pauses here until all tasks finish.

2. User Data Fetching Method

```
static async Task fetchUserDataAsync(string url)
{
    using (var httpClient = new HttpClient())
    {
        try
        {
            Console.WriteLine("Fetching user data...");
            var response = await httpClient.GetAsync(url);
            Task.Delay(3000).Wait();
            Console.WriteLine("User data is delayed for 3 seconds.");
            var data = await response.Content.ReadAsStringAsync();
            Console.WriteLine(data);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }
    }
}
```

- Uses `async` to allow the use of `await` inside.
- Initially prints the Messgae of `Fetching user data...` as a method starting intimation.
- Fetchs the User data with help of `await` and `httpClient.GetAsync()`.
- Uses `await` to avoid blocking the current thread.
- Before printing the fetched user data task is delayed for 3 seconds using `Task.Delay(3000).wait()`.
- Reads the response content as a string asynchronously.
- After 3 seconds the fetched data will be printed on the console.

3. Post Data Fetching Method

```
static async Task fetchPostDataAsync(string url)
{
    using (var httpClient = new HttpClient())
    {
        try
        {
            Console.WriteLine("Fetching post data...");
            var response = await httpClient.GetAsync(url);
            Task.Delay(2000).Wait();
            Console.WriteLine("Post data is delayed for 2 seconds.");
            var postData = await response.Content.ReadAsStringAsync();
            Console.WriteLine(postData);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }
    }
}
```

- Uses `async` to allow the use of `await` inside.
- Initially prints the Messgae of `Fetching post data...` as a method starting intimation.
- Fetchs the post data with help of `await` and `httpClient.GetAsync()`.
- Uses `await` to avoid blocking the current thread.
- Before printing the fetched user data task is delayed for 2 seconds using `Task.Delay(2000).wait()`.
- Reads the response content as a string asynchronously.
- After 2 seconds the fetched data will be printed on the console.

4. Comments Data Fetching Method

```
static async Task fetchCommentDataAsync(string url)
{
    using (var httpClient = new HttpClient())
    {
        try
        {
            Console.WriteLine("Fetching comment data...");
            var response = await httpClient.GetAsync(url);
            Task.Delay(1000).Wait();
            Console.WriteLine("Comment data is delayed for 1 second.");
            var commentsdata = await response.Content.ReadAsStringAsync();
            Console.WriteLine(commentsdata);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Request error: {e.Message}");
        }
    }
}
```

- Uses `async` to allow the use of `await` inside.
- Initially prints the Messgae of `Fetching comment data...` as a method starting intimation.
- Fetchs the post data with help of `await` and `httpClient.GetAsync()`.
- Uses `await` to avoid blocking the current thread.
- Before printing the fetched user data task is delayed for 1 seconds using `Task.Delay(1000).wait()`.
- Reads the response content as a string asynchronously.
- After 1 seconds the fetched data will be printed on the console.


## Task Output

- Due to delay in the each task method and api call, api response is displayed in reverse order.
- First the Comments data will be printend followed by Posts data and User data.

![Async-Await](./assets/async.gif)