using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scrapper;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class DBController : Controller
    {
        [HttpGet]
        public async Task Init(){
            await Repository.Create();
            List<Show> shows = await TvMazeScrapper.Scrap();
            await Repository.Save(shows);
        }

        [HttpGet]
        public async Task Drop(){
            await Repository.Drop();
        }
    }
}