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
        private IGetWeather _getWeatherFromSMHI = new GetWeather();
        private IStationRepository _stationRepository = new StationRepository();

        [Route("SeedTopTen"), HttpPost]
        public IActionResult SeedTopTen()
        {
            _stationRepository.ClearDatabase();
            var topTen = _getWeatherFromSMHI.GetForecastTopTenCities();
            _stationRepository.AddStations(topTen);
            return Ok("Sucessfully seeded top ten cities.");

        }

        [Route("getTopTenCityNames"), HttpGet]
        public IActionResult GetTopTenCityNames()
        {
            var cities = _getWeatherFromSMHI.GetForecastTopTenCities();
            return Json(cities.Select(c => c.Name));
        }
    }
}
