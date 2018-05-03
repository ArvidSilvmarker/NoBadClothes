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
                Temperature = getMeanTemperature(station, datetime, duration),
                Precipation = getWorstPrecipation(station, datetime, duration)
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
    }

}
