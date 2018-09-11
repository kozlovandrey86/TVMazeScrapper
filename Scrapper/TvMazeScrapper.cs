using System;
using System.Net.Http;

namespace Scrapper
{
    public class TvMazeScrapper
    {
        public static void Scrap()
        {
            HttpClient client = new HttpClient();
            string str = await client.GetStringAsync("http://api.tvmaze.com/shows/");
           

            string[] lines = await File.ReadAllLinesAsync("tvmazecast.json");



            client.Dispose();
        }
    }
}
