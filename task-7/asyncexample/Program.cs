using System.Threading.Tasks;
using System;
using System.Net.Http;

namespace AsyncExample
{

    public class Program
    {
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

    }
}