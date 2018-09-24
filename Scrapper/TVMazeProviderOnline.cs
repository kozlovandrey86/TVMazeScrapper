using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Newtonsoft.Json;
using System.Linq;

namespace Scrapper
{
    public class TVMazeProviderOnline : ITVMazeProvider
    {
        public async Task FillShows(List<Show> shows)
        {
            //each chunk by 20 shows to scrap casts for each show (in parallel)
            foreach (var chunk in PartitionShows(shows))
            {
                await ScrapCasts(chunk);
                await Task.Delay(10000);  //rate limit 20 calls every 10 seconds
            }

        }

        public async Task<List<Show>> GetShows()
        {
            List<Show> shows = null;
            using (HttpClient client = new HttpClient())
            {
                string lines = await client.GetStringAsync("http://www.tvmaze.com/api");
                shows = JsonConvert.DeserializeObject<List<Show>>(lines);
            }
            return shows;
        }


        private static IEnumerable<IEnumerable<Show>> PartitionShows(List<Show> shows, int chunkSize = 20)
        {
            int i = 0;
            do
            {
                yield return shows.Skip(i).Take(chunkSize);
                i += chunkSize;
            } while (i <= shows.Count);
        }

        private static async Task ScrapCasts(IEnumerable<Show> shows)
        {
            using (HttpClient client = new HttpClient())
            {
                
                string lines = await client.GetStringAsync($"http://www.tvmaze.com/api/shows/{id}");
                shows = JsonConvert.DeserializeObject<List<Show>>(lines);
            }


            string lines = await File.ReadAllTextAsync("wwwroot\\tvmazecast.json");
            foreach (var show in shows)
            {
                show.Casts = JsonConvert.DeserializeObject<IEnumerable<Cast>>(lines).ToList();
            }
            await Task.Yield();
        }

    }
}
