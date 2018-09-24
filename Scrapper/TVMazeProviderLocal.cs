using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapper
{
    //For testing purpose
    public class TVMazeProviderLocal: ITVMazeProvider
    {
        public async Task<List<Show>> GetShows()
        {
            List<Show> shows = null;
            try
            {
                string lines = await File.ReadAllTextAsync("wwwroot\\tvmazeshows.json");
                shows = JsonConvert.DeserializeObject<List<Show>>(lines);
            }
            catch (Exception ex)
            {
                //TODO:logging
            }
            return shows;
        }

        public async Task FillShows(List<Show> shows)
        {
            //each chunk by 20 shows to scrap casts for each show (in parallel)
            foreach (var chunk in PartitionShows(shows))
            {
                await ScrapCasts(chunk);
                //await Task.Delay(10000);  //rate limit 20 calls every 10 seconds
            }
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
            string lines = await File.ReadAllTextAsync("wwwroot\\tvmazecast.json");
            foreach (var show in shows)
            {
                show.Casts = JsonConvert.DeserializeObject<IEnumerable<Cast>>(lines).ToList();
            }
            await Task.Yield();
        }
    }
}
