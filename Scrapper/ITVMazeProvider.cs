using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrapper
{
    public  interface ITVMazeProvider
    {
        Task<List<Show>> GetShows();
        Task FillShows(List<Show> shows);
    }
}
