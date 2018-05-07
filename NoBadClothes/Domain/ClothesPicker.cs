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
        private const int TEMPforWinterClothes = 5;

        private StationRepository stationRepository = new StationRepository();
        private ClothesPackages _clothesPackages = new ClothesPackages();

        public List<string> GetClothes(string cityName, DateTime datetime, int duration)
        {

            Station station = stationRepository.GetStation(cityName);
            var parameters = new ClothingParameters(station, datetime, duration);
            return CalculateClothes(parameters); ;
        }

        private List<string> CalculateClothes(ClothingParameters parameters)
        {
            var clothes = new List<string>();
            if (parameters.Temperature < TEMPforWinterClothes)
                clothes.AddRange(ClothesPackages.WinterClothes);

            else if (parameters.Precipation > 0)
                clothes.AddRange(ClothesPackages.RainClothes);
            
            else if (parameters.Temperature < 15)
                clothes.AddRange(ClothesPackages.SpringClothes);
    
            else if (parameters.Temperature > 25)
                clothes.AddRange(ClothesPackages.SummerShoes);
            else
                clothes.AddRange(ClothesPackages.BaseShoes);
            return clothes;
        }

        private List<string> GetMidClothes(ClothingParameters parameters)
        {
            var clothes = new List<string>();
            if (parameters.Temperature < 15)
                clothes.AddRange(ClothesPackages.BaseClothes);
            else
                clothes.AddRange(ClothesPackages.SummerClothes);
            return clothes;
        }

        

    }

}
