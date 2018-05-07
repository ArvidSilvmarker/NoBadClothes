using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoBadClothes.Data;
using NoBadClothes.Domain;
using NoBadClothes.Domain.Interfaces;

namespace NoBadClothes
{
    public class ClothesPicker
    {
        private const double MAXTemperatureForWinterClothes = 5;
        private const double MINPrecipationForRainClothes = 0;
        private const double MAXTemperatureForSpringClothes = 15;
        private const double MINTemperatureForSummerShoes = 25;

        private readonly IStationRepository _stationRepository = new StationRepository();

        public List<string> GetClothes(string cityName, DateTime datetime, int duration)
        {

            Station station = _stationRepository.GetStation(cityName);
            var parameters = new ClothingParameters(station, datetime, duration);
            return CalculateClothes(parameters); ;
        }

        private List<string> CalculateClothes(ClothingParameters parameters)
        {
            var clothes = new List<string>();

            if (parameters.Temperature < MAXTemperatureForWinterClothes)
                clothes.AddRange(ClothesPackages.WinterClothes);
            else if (parameters.Precipation > MINPrecipationForRainClothes)
                clothes.AddRange(ClothesPackages.RainClothes);
            else if (parameters.Temperature < MAXTemperatureForSpringClothes)
                clothes.AddRange(ClothesPackages.SpringClothes);
            else if (parameters.Temperature > MINTemperatureForSummerShoes)
                clothes.AddRange(ClothesPackages.SummerShoes);
            else
                clothes.AddRange(ClothesPackages.BaseShoes);

            if (parameters.Temperature < MAXTemperatureForSpringClothes)
                clothes.AddRange(ClothesPackages.BaseClothes);
            else
                clothes.AddRange(ClothesPackages.SummerClothes);

            return clothes;
        }
    }
}
