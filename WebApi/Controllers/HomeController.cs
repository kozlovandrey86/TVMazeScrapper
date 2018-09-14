using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet("/index")]
        public string Index(){
            return "Home Page";
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<Show> Get()
        {
            return Repository.GetShows();

        }

        
    }
}
