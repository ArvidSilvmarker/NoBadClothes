using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoBadClothes.Domain.Interfaces
{
    interface IStationRepository
    {
        void ClearDatabase();
        void AddStations(List<Station> stationList);
        Station GetStation(string cityName);
    }
}
