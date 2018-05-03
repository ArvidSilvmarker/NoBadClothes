using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoBadClothes.Data;
using NoBadClothes.Domain;

namespace NoBadClothes
{
    public class ClothesPicker
    {
        private StationRepository stationRepository = new StationRepository();

        public void OutherLayer(double temperature, PrecipationCategory precipationCategory)
        {
            

            if (temperature < 10)
            {

            }

        }


        public ClothesSuggestion getClothes(string cityName, DateTime datetime, int duration)
        {
            Station station = stationRepository.GetStation(cityName);
            var parameters = new ClothingParameters
            {
                Temperature = GetMeanTemperature(station, datetime, duration),
                Precipation = GetWorstPrecipation(station, datetime, duration)
            };


            var suggestion = new ClothesSuggestion();
            suggestion = GetInnerClothes(suggestion, parameters);
            suggestion = GetMiddleClothes(suggestion, parameters);
            suggestion = GetOuterClothes(suggestion, parameters);

            return suggestion;
        }

        private ClothesSuggestion GetOuterClothes(ClothesSuggestion suggestion, ClothingParameters parameters)
        {
            if (parameters.Precipation > 3)
                suggestion.ClothesList.Add(Raincoat);
        }

        public double GetMeanTemperature(Station station, DateTime from, int duration)
        {
            DateTime to = from.AddHours(duration);
            var weatherDuringPeriod = new List<Weather>();
            foreach (var weather in station.WeatherForecast)
            {
                if (weather.Time => from && weather.Time <= to)
                    weatherDuringPeriod.Add(weather);
            }

            double totalTemp = 0;
            foreach (var weather in weatherDuringPeriod)
            {
                totalTemp += weather.Temperature;
            }

            return totalTemp / weatherDuringPeriod.Count;
        }
    }

}
