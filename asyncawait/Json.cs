using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class JsonHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task Process()
        {
            Task p1 = ProcessRepositories();
            await p1;
        }
        public static async Task ProcessRepositories()
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(
                //    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                //var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

                //var stringTask = client.GetStringAsync("https://localhost:44355/api/todoitems");
                //var msg = await stringTask;
                //Console.WriteLine(msg);

                var streamTask = client.GetStreamAsync("https://localhost:44355/api/todoitems");
                var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
                if (repositories != null)
                {
                    foreach (var rep in repositories)
                        Console.WriteLine(rep.Name11);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

    }
    public class Repository
    {
        [JsonPropertyName("name")]
        public string Name11 { get; set; }
    }

}
