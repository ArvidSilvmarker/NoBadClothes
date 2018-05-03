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
        private Clothes clothes = new Clothes();

        public List<ClothesSuggestion> GetClothes(string cityName, DateTime datetime, int duration)
        {
            List<Clothes> possibleClothes = clothes.PossibleClothes();
            Station station = stationRepository.GetStation(cityName);
            var parameters = new ClothingParameters
            {
                Temperature = GetMeanTemperature(station, datetime, duration),
                Precipation = GetWorstPrecipation(station, datetime, duration)
            };

            var suggestions = new List<ClothesSuggestion>();
            // suggestion = GetInnerClothes(suggestion, parameters);
            //suggestion = GetMiddleClothes(suggestion, parameters);
            suggestions = GetOuterClothes(suggestions, parameters, possibleClothes);
            return suggestions;
        }

        private List<ClothesSuggestion> GetOuterClothes(List<ClothesSuggestion> suggestions, ClothingParameters parameters, List<Clothes> possibleClothes)
        {
            if (parameters.Precipation > 0)
            {
                var suggestion = new ClothesSuggestion();
                suggestion.Clothes = possibleClothes.First(c => c.Name == "Regnjacka");
                suggestions.Add(suggestion);

            }
            else
            {
                var suggestion = new ClothesSuggestion();
                suggestion.Clothes = possibleClothes.First(c => c.Name == "Vantar");
                suggestions.Add(suggestion);

            }
            return suggestions;

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
