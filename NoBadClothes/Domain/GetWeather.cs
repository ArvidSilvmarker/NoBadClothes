using System;
using System.Collections.Generic;
using System.IO;
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
            string scheme = @"https://";
            string hostPath = 
                $"opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/{CoordinateWithDot(longitude)}/lat/{CoordinateWithDot(latitude)}/data.json";
            string url = scheme + hostPath;
            File.WriteAllText(@"log.txt",url);
            var jsonTemp = new WebClient().DownloadString(url);
            var jsonTempObject = (JObject)JsonConvert.DeserializeObject(jsonTemp);
            return jsonTempObject;
        }

        public JObject GetJsonForecastGothenburg()
        {
            double longitude = 11.974560;
            double latitude = 57.708870;
            
            return GetJsonForecast(longitude, latitude);
        }

        public string CoordinateWithDot(double coordinate)
        {
            return coordinate.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture);
        }


    }
}
