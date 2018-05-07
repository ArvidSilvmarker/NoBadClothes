using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoBadClothes.Data;
using NoBadClothes.Domain.Interfaces;

namespace NoBadClothes.Controllers
{
    [Route("api/clothes")]
    public class ClothesController : Controller
    {
        private readonly ClothesPicker clothesPicker = new ClothesPicker();

        [Route("getClothes"), HttpGet]
        public IActionResult GetClothes(string cityName, DateTime datetime, int hour)
        {
            List<string> suggestion = clothesPicker.GetClothes(cityName, datetime, hour);
            return Ok(string.Join("<br>", suggestion));
        }

        [Route("getClothesImg"), HttpGet]
        public IActionResult GetClothesImg(string cityName, DateTime datetime, int hour)
        {
            List<string> suggestion = clothesPicker.GetClothes(cityName, datetime, hour);
            string outputResult = "";

            foreach (var clothes in suggestion)
            {
                outputResult += $"<img src=img/{clothes}.png width=\"200px\" height=\"200px\"/><br />";
            }
            return Ok(outputResult);

        }
    }
}
