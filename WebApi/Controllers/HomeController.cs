using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Scrapper;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("Index")]
        public string Index(){
            return "Home Page";
        }
        // GET api/values
        [HttpGet("AllShows")]
        public string AllShows()
        {
            var shows = _repository.GetAllShows();
            if (shows != null && shows.Count()>0)
                return JsonConvert.SerializeObject(shows);
            return  "Init database via AdminController";
        }

        [HttpGet("Shows/{page}")]
        public async Task<string> Shows(int page=1){
            var shows = await _repository.GetShows(page: page);
            if (shows != null && shows.Count() > 0)
            {
                //var showsOrderByDescBirthday = from s in shows
                //          select new { id = s.Id, cast = s.Casts.OrderByDescending(c => c.Birthday) };
                return JsonConvert.SerializeObject(shows);
            }
            return "Init database via AdminController";
        }
    }
}
