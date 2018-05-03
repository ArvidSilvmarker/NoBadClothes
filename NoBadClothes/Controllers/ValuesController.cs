﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoBadClothes.Data;

namespace NoBadClothes
{
    [Route("api/weather")]
    public class ValuesController : Controller
    {
        private GetWeather _getWeatherFromSMHI = new GetWeather();
        private StationRepository stationRepository = new StationRepository();

        [Route("gbgnexthourtemp"), HttpGet]
        public IActionResult GbgNextHourTemp()
        {
            Station station = new Station {Name = "Göteborg", Latitude = 57.4018, Longitude = 11.5851};
            Forecast goteborgForecast = _getWeatherFromSMHI.GetJsonForecast(station);
            DateTime nextFullHour = new DateTime(DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour+1, 0,0);
            string temp = goteborgForecast.timeSeries.First(t => t.validTime == nextFullHour).parameters.First(p => p.name == "t").values[0].ToString();
            return Ok($"Temperaturen i {station.Name} klockan {nextFullHour.TimeOfDay} blir {temp} grader.");
        }

        [Route("SeedTopTen"), HttpPost]
        public IActionResult SeedTopTen()
        {
            stationRepository.ClearDatabase();
            var topTen = _getWeatherFromSMHI.GetForecastTopTenCities();
            stationRepository.AddStations(topTen);
            return Ok("Sucessfully seeded top ten cities.");

        }

        [Route("getweathertime"), HttpGet]
        public IActionResult GetWeatherTime(string cityName, DateTime datetime)
        {
            var station = stationRepository.GetStation(cityName);
            var weather = station.WeatherForecast.First(w => w.Time == datetime);
            return Ok(
                $"Vädret i {station.Name} klockan {datetime.TimeOfDay}: {weather.Temperature} grader och {weather.PrecipationCategory.ToString()}");
        }

        [Route("getweathertomorrow"), HttpGet]
        public IActionResult GetWeatherTomorrow(string cityName)
        {
            var tomorrow = DateTime.Today.AddDays(1).AddHours(12);
            var station = stationRepository.GetStation(cityName);
            var weather = station.WeatherForecast.First(w => w.Time == tomorrow);
            return Ok(tomorrow.ToString());
        }

    }
}
