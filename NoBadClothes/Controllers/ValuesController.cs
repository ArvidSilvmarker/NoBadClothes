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
                return Ok("!!!!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [Route("toptencities2"), HttpGet]
        public IActionResult TopTenCities2(string test)
        {
            try
            {
                Forecast goteborgForecast = _getWeatherFromSMHI.GetJsonForecast2(new Station { Name = "Göteborg", Latitude = 57.4018, Longitude = 11.5851 });
                string text = goteborgForecast.timeSeries[0].parameters[11].values[0].ToString();
                return Ok(test);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}
