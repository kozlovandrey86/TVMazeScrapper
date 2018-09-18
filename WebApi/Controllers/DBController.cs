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
    [Route("DB")]
    public class DBController : Controller
    {
        private readonly ITvMazeScrapper _mazeScrapper;
        private readonly IRepository _repository;

        public DBController(ITvMazeScrapper mazeScrapper, IRepository repository)
        {
            _mazeScrapper = mazeScrapper;
            _repository = repository;
        }
        [HttpGet("Init")]
        public async Task Init(){
            await _repository.Create();
            List<Show> shows = await _mazeScrapper.Scrap();
            await _repository.Save(shows);
        }

        [HttpGet("Refresh")]
        public async Task Refresh()
        {
            await _repository.Drop();
            await _repository.Create();
            List<Show> shows = await _mazeScrapper.Scrap();
            await _repository.Save(shows);
        }


        [HttpGet("Drop")]
        public async Task Drop(){
            await _repository.Drop();
        }
    }
}