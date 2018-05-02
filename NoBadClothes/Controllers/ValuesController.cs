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
        private GetWeather _getWeatherFromSMHI = new GetWeather();

        [Route("toptencities"), HttpGet]
        public IActionResult TopTenCities(string test)
        {
            try
            {
                var topTen = _getWeatherFromSMHI.GetForecastTopTenCities();
                return Json(topTen);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
       
    }
}
