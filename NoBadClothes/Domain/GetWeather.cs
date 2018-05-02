using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NoBadClothes
{
    public class GetWeather
    {
        public JObject GetJsonForecast(double longitude, double latitude )
        {
            var jsonTemp = new WebClient().DownloadString($"https://opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/{longitude}/lat/{latitude}/data.json");
            var jsonTempObject = (JObject)JsonConvert.DeserializeObject(jsonTemp);
            return jsonTempObject;

            var exempel = (string)jsonTempObject["timeSeries"][0]["parameters"][0]["name"];
            Console.WriteLine(exempel);
        }
        //hämta Json från SMHI
    }
}
