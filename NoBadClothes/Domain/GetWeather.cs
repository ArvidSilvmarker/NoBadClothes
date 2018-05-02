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
        private ReadWeather _weatherReader = new ReadWeather();

        public Station GetForecast(Station station)
        {
            return _weatherReader.UpdateStation(GetJsonForecast(station), station);
        }

        public List<Station> GetForecasts(List<Station> stations)
        {
            return stations.Select(GetForecast).ToList();
        }

        public JObject GetJsonForecast(Station station)
        {
            string scheme = @"https://";
            string hostPath = 
                $"opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/{CoordinateWithDot(station.Longitude)}/lat/{CoordinateWithDot(station.Latitude)}/data.json";
            string url = scheme + hostPath;
            File.WriteAllText(@"log.txt",url);
            var jsonTemp = new WebClient().DownloadString(url);
            var jsonTempObject = (JObject)JsonConvert.DeserializeObject(jsonTemp);
            return jsonTempObject;
        }

        public Forecast GetJsonForecast2(Station station)
        {
            string scheme = @"https://";
            string hostPath =
                $"opendata-download-metfcst.smhi.se/api/category/pmp3g/version/2/geotype/point/lon/{CoordinateWithDot(station.Longitude)}/lat/{CoordinateWithDot(station.Latitude)}/data.json";
            string url = scheme + hostPath;
            File.WriteAllText(@"log.txt", url);

            var json = new WebClient().DownloadString(url);
            Forecast forecast = JsonConvert.DeserializeObject<Forecast>(json);
            return forecast;
        }

        public string CoordinateWithDot(double coordinate)
        {
            return coordinate.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture);
        }


        public List<Station> GetForecastTopTenCities()
        {
            List<Station> topTen = new List<Station>();
            topTen.Add(new Station { Name = "Stockholm", Latitude = 59.1446, Longitude = 18.47 });
            topTen.Add(new Station { Name = "Göteborg", Latitude = 57.4018, Longitude = 11.5851 });
            topTen.Add(new Station { Name = "Malmö", Latitude = 55.3535, Longitude = 13.117 });
            topTen.Add(new Station { Name = "Uppsala", Latitude = 59.5059, Longitude = 17.3820 });
            topTen.Add(new Station { Name = "Västerås", Latitude = 59.372, Longitude = 16.3231 });
            topTen.Add(new Station { Name = "Örebro", Latitude = 59.161, Longitude = 15.1147 });
            topTen.Add(new Station { Name = "Linköping", Latitude = 58.2434, Longitude = 15.3732 });
            topTen.Add(new Station { Name = "Helsingborg", Latitude = 56.233, Longitude = 12.4316 });
            topTen.Add(new Station { Name = "Jönköping", Latitude = 57.4649, Longitude = 14.1539 });
            topTen.Add(new Station { Name = "Norrköping", Latitude = 58.3446, Longitude = 16.858 });
            return GetForecasts(topTen);
        }
    }
}
