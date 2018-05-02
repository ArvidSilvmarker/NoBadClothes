using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json.Linq;

namespace NoBadClothes
{
    public class ReadWeather
    {
        public Station UpdateStation(Forecast forecast, Station station)
        {
            
        }

        public Station buildWeather(Forecast forecast, Station station, DateTime time)
        {
            Weather weather = new Weather ();
            DateTime nextFullHour = new DateTime(time.Year, time.Month, time.Day, time.Hour + 1, 0, 0);

            weather.Temperature = forecast.timeSeries.First(t => t.validTime == nextFullHour).parameters.First(p => p.name == "t").values[0];
            weather.WindDirection = (int)forecast.timeSeries.First(t => t.validTime == nextFullHour).parameters.First(p => p.name == "wd").values[0];
            weather.WindSpeed = forecast.timeSeries.First(t => t.validTime == nextFullHour).parameters.First(p => p.name == "ws").values[0];


            weather.WindGust = forecast.timeSeries.First(t => t.validTime == nextFullHour).parameters.First(p => p.name == "gust").values[0];
            weather.PrecipationCategory = (PrecipationCategory)forecast.timeSeries.First(t => t.validTime == nextFullHour).parameters.First(p => p.name == "pcat").values[0];
            weather.WeatherSymbol = (WeatherSymbol)forecast.timeSeries.First(t => t.validTime == nextFullHour).parameters.First(p => p.name == "Wsymb2").values[0];
            weather.PrecipationMean = forecast.timeSeries.First(t => t.validTime == nextFullHour).parameters.First(p => p.name == "pmean").values[0];

            station.

            
            return station;

        }
        //läs Json och skapa objekt
    }
}
