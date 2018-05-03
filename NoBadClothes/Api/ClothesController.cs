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
            var json = clothesPicker.GetClothes(cityName, datetime, hour);

            return Json(json);

        }
    }
}
