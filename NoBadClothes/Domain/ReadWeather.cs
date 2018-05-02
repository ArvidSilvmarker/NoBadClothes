using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NoBadClothes
{
    public class ReadWeather
    {
        public Station UpdateStation(JObject jObject, Station station)
        {
            DateTime referenceTime = (DateTime)jObject["referenceTime"];

            var temperature = (double)jObject["timeSeries"][0]["parameters"][11]["values"][0];
            var windDirection = (int)jObject["timeSeries"][0]["parameters"][13]["values"][0];
            var windSpeed = (double)jObject["timeSeries"][0]["parameters"][14]["values"][0];
            var WindGust = (double)jObject["timeSeries"][0]["parameters"][17]["values"][0];
            // var pCat = (int)jObject["timeSeries"][0]["parameters"][17]["values"][0];
            var weatherSymbol = (int)jObject["timeSeries"][0]["parameters"][18]["values"][0];


            station.MorningWeather.Temperature = temperature;
            return station;
        }
        //läs Json och skapa objekt
    }
}
