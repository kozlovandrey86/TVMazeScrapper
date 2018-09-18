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
        [HttpGet("Get")]
        public string Get()
        {
            var shows = _repository.GetShows();
            if (shows != null && shows.Count()>0)
                return JsonConvert.SerializeObject(shows);
            return  "Init database via AdminController";
        }
        
    }
}
