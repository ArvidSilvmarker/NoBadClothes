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

        [Route("gbgnexthourtemp"), HttpGet]
        public IActionResult GbgNextHourTemp()
        {
            Station station = new Station {Name = "Göteborg", Latitude = 57.4018, Longitude = 11.5851};
            Forecast goteborgForecast = _getWeatherFromSMHI.GetJsonForecast2(station);
            DateTime nextFullHour = new DateTime(DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour+1, 0,0);
            string temp = goteborgForecast.timeSeries.First(t => t.validTime == nextFullHour).parameters.First(p => p.name == "t").values[0].ToString();
            return Ok($"Temperaturen i {station.Name} klockan {nextFullHour.TimeOfDay} blir {temp} grader.");
        }

    }
}
