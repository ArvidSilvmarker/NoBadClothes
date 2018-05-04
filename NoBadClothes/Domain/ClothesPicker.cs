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
            
            suggestions = GetOuterClothes(suggestions, parameters, possibleClothes);
            suggestions = GetMidClothes(suggestions, parameters, possibleClothes);
            return suggestions;
        }

        private List<ClothesSuggestion> GetOuterClothes(List<ClothesSuggestion> suggestions, ClothingParameters parameters, List<Clothes> possibleClothes)
        {
            if (parameters.Temperature < 5)
            {
                var suggestion = new ClothesSuggestion{Clothes = possibleClothes.First(c => c.Name == "Vinterjacka") };
                suggestions.Add(suggestion);
                var suggestion1 = new ClothesSuggestion{Clothes = possibleClothes.First(c => c.Name == "Vantar") };
                suggestions.Add(suggestion1);
                var suggestion2 = new ClothesSuggestion{ Clothes = possibleClothes.First(c => c.Name == "Mössa") };
                suggestions.Add(suggestion2);
                var suggestion3 = new ClothesSuggestion { Clothes = possibleClothes.First(c => c.Name == "Vinterstövlar") };
                suggestions.Add(suggestion3);
            }

            else if (parameters.Precipation > 0)
            {
                var suggestion = new ClothesSuggestion{Clothes = possibleClothes.First(c => c.Name == "Regnjacka") };
                suggestions.Add(suggestion);
                var suggestion1 = new ClothesSuggestion { Clothes = possibleClothes.First(c => c.Name == "Stövlar") };
                suggestions.Add(suggestion1);
            }
            else if (parameters.Temperature < 15)
            {
                var suggestion = new ClothesSuggestion{ Clothes = possibleClothes.First(c => c.Name == "Sommarjacka") };
                suggestions.Add(suggestion);
                var suggestion1 = new ClothesSuggestion { Clothes = possibleClothes.First(c => c.Name == "Gympaskor") };
                suggestions.Add(suggestion1);
            }
            else if (parameters.Temperature > 25)
            {
                var suggestion = new ClothesSuggestion { Clothes = possibleClothes.First(c => c.Name == "Sandaler") };
                suggestions.Add(suggestion);

            }
            else
            {
                var suggestion = new ClothesSuggestion { Clothes = possibleClothes.First(c => c.Name == "Gympaskor") };
                suggestions.Add(suggestion);
            }
            return suggestions;

        }

        private List<ClothesSuggestion> GetMidClothes(List<ClothesSuggestion> suggestions, ClothingParameters parameters, List<Clothes> possibleClothes)
        {
            if (parameters.Temperature < 18)
            {
                var suggestion = new ClothesSuggestion { Clothes = possibleClothes.First(c => c.Name == "Långbyxor") };
                suggestions.Add(suggestion);
                var suggestion1 = new ClothesSuggestion { Clothes = possibleClothes.First(c => c.Name == "Tröja") };
                suggestions.Add(suggestion1);
                var suggestion2 = new ClothesSuggestion { Clothes = possibleClothes.First(c => c.Name == "T-tröja") };
                suggestions.Add(suggestion2);
            }
            else
            {
                var suggestion = new ClothesSuggestion { Clothes = possibleClothes.First(c => c.Name == "Shorts") };
                suggestions.Add(suggestion);
                var suggestion1 = new ClothesSuggestion { Clothes = possibleClothes.First(c => c.Name == "T-tröja") };
                suggestions.Add(suggestion1);
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
