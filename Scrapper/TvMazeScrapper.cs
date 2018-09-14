using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Scrapper
{
    public class TvMazeScrapper
    {
        public static async Task<List<Show>> Scrap()
        {
            //HttpClient client = new HttpClient();
            //string str = await client.GetStringAsync("http://api.tvmaze.com/shows/");
            List<Show> shows = null;
            try
            {
                shows = await TVMazeProvider.GetShows();
                await TVMazeProvider.FillShows(shows);
            }
            catch(Exception ex){
                //TODO:logging
            }

            return shows;
        }

       
    }
}
