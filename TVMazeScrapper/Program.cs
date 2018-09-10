using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;

namespace TVMazeScrapper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            string str = await client.GetStringAsync("http://api.tvmaze.com/shows/");
            Console.WriteLine(str);
            Console.ReadKey();

            string[] lines = await File.ReadAllLinesAsync("tvmazecast.json");
            


            client.Dispose();
            
        }


    }
}
