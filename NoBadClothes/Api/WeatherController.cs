using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoBadClothes.Data;
using NoBadClothes.Domain.Interfaces;

namespace NoBadClothes
{
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        private readonly IGetWeather _getWeather = new GetWeatherFromSmhi();
        private readonly IStationRepository _stationRepository = new StationRepository();

        [Route("SeedTopTen"), HttpPost]
        public IActionResult SeedTopTen()
        {
            try
            {
                _stationRepository.ClearDatabase();
                var topTen = _getWeather.GetForecastTopTenCities();
                _stationRepository.AddStations(topTen);
                return Ok("Successfully seeded top ten cities.");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [Route("getTopTenCityNames"), HttpGet]
        public IActionResult GetTopTenCityNames()
        {
            try
            {
                var cities = _getWeather.GetForecastTopTenCities();
                return Json(cities.Select(c => c.Name));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
