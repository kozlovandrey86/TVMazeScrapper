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
    public class TvMazeScrapper: ITvMazeScrapper
    {
        private readonly ITVMazeProvider _mazeProvider;
        public TvMazeScrapper(ITVMazeProvider mazeProvider)
        {
            _mazeProvider = mazeProvider;
        }
        public async Task<List<Show>> Scrap()
        {
            //HttpClient client = new HttpClient();
            //string str = await client.GetStringAsync("http://api.tvmaze.com/shows/");
            List<Show> shows = null;
            try
            {
                shows = await _mazeProvider.GetShows();
                await _mazeProvider.FillShows(shows);
            }
            catch(Exception ex){
                //TODO:logging
            }

            return shows;
        }

       
    }
}
