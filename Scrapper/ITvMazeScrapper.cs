using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Scrapper
{
    public interface ITvMazeScrapper
    {
        Task<List<Show>> Scrap();
    }
}
