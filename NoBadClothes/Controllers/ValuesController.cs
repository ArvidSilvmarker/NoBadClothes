using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NoBadClothes
{
    [Route("api/weather")]
    public class ValuesController : Controller
    {

        [Route("test"), HttpGet]
        public IActionResult Test(string test)
        {



            return Ok("Väder!");
        }
       
    }
}
