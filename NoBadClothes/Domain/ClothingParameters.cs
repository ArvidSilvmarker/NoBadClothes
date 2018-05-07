using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoBadClothes.Domain
{
    public class ClothingParameters
    {
        public double Temperature { get; set; }
        public PrecipationCategory PrecipationCategory { get; set; }
        public double Precipation { get; set; }

        public ClothingParameters()
        {
                Temperature = GetMeanTemperature(station, datetime, duration),
                Precipation = GetWorstPrecipation(station, datetime, duration)
        }

        public double GetMeanTemperature(Station station, DateTime from, int duration)
        {
            DateTime to = from.AddHours(duration);
            var weatherDuringPeriod = new List<Weather>();
            foreach (var weather in station.WeatherForecast)
            {
                if (weather.Time >= from && weather.Time <= to)
                    weatherDuringPeriod.Add(weather);
            }

            double totalTemp = 0;
            foreach (var weather in weatherDuringPeriod)
            {
                totalTemp += weather.Temperature;
            }

            return totalTemp / weatherDuringPeriod.Count;
        }

        public double GetWorstPrecipation(Station station, DateTime from, int duration)
        {
            DateTime to = from.AddHours(duration);
            var weatherDuringPeriod = new List<Weather>();
            foreach (var weather in station.WeatherForecast)
            {
                if (weather.Time >= from && weather.Time <= to)
                    weatherDuringPeriod.Add(weather);
            }

            double worstPrecipation = 0;
            foreach (var weather in weatherDuringPeriod)
            {
                if (weather.PrecipationMean > worstPrecipation)
                    worstPrecipation = weather.PrecipationMean;
            }
            return worstPrecipation;
        }
    }
}
