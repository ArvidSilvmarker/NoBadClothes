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
        private ClothesPicker clothesPicker = new ClothesPicker();

        [Route("getClothes"), HttpGet]
        public IActionResult getClothes(string cityName, DateTime datetime, int hour)
        {
            List<string> suggestion = clothesPicker.GetClothes(cityName, datetime, hour).Select(c => c.Clothes).Select(c => c.Name).ToList();

            string outputResult = string.Join("<br>", suggestion);
            return Ok(outputResult);

        }

        [Route("getClothesImg"), HttpGet]
        public IActionResult getClothesImg(string cityName, DateTime datetime, int hour)
        {
            List<string> suggestion = clothesPicker.GetClothes(cityName, datetime, hour).Select(c => c.Clothes).Select(c => c.Name).ToList();

            string outputResult = "";
            foreach (var clothes in suggestion)
            {
                outputResult += $"<img src=img/{clothes}.png width=\"200px\" height=\"200px\"/><br />";
            }
            return Ok(outputResult);

        }
    }
}
