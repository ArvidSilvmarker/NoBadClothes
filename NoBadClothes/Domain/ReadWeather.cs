using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NoBadClothes
{
    public class ReadWeather
    {
        public string ReadJson(JObject jObject)
        {
            var example = (string)jObject["timeSeries"][0]["parameters"][0]["name"];
            return example;
        }
        //läs Json och skapa objekt
    }
}
