using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json.Linq;

namespace NoBadClothes
{
    public class WeatherMapper
    {
        public Station UpdateStation(Forecast forecast, Station station)
        {
            station.ReferenceTime = forecast.referenceTime;
            foreach (var timeseries in forecast.timeSeries)
            {
                buildWeather(station, timeseries);
            }
            return station;
        }

        public void buildWeather(Station station, Forecast.Timeseries timeSeries)
        {
            Weather weather = new Weather ();

            weather.Time = timeSeries.validTime;
            weather.Temperature = timeSeries.parameters.First(p => p.name == "t").values[0];
            weather.WindDirection = (int)timeSeries.parameters.First(p => p.name == "wd").values[0];
            weather.WindSpeed = timeSeries.parameters.First(p => p.name == "ws").values[0];

            weather.WindGust = timeSeries.parameters.First(p => p.name == "gust").values[0];

            weather.PrecipationCategory = (PrecipationCategory)timeSeries.parameters.First(p => p.name == "pcat").values[0];
            weather.WeatherSymbol = (WeatherSymbol)timeSeries.parameters.First(p => p.name == "Wsymb2").values[0];
            weather.PrecipationMean = timeSeries.parameters.First(p => p.name == "pmean").values[0];

            station.WeatherForecast.Add(weather);
        }
    }
}
