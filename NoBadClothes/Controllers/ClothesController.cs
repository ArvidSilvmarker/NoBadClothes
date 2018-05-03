using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoBadClothes.Data;

namespace NoBadClothes.Controllers
{
    [Route("api/clothes")]
    public class ClothesController : Controller
    {
        private StationRepository stationRepository = new StationRepository();

        [Route("getClothes"), HttpGet]
        public IActionResult getOuterLayer(string cityName, DateTime datetime, int hour)
        {
            var station = stationRepository.GetStation(cityName);
            var temp = station.WeatherForecast[0].Temperature;


            return (Ok(temp));

        }
    }
}
