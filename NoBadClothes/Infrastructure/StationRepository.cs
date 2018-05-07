using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoBadClothes.Domain.Interfaces;

namespace NoBadClothes.Data
{
    public class StationRepository : IStationRepository
    {
        private readonly NoBadContext _context = new NoBadContext();

        public void ClearDatabase()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public void AddStations(List<Station> stationList)
        {
                _context.Stations.AddRange(stationList);
                _context.SaveChanges();
        }

        public Station GetStation(string cityName)
        {
            return _context.Stations.Include(s => s.WeatherForecast).FirstOrDefault(s => s.Name == cityName);
        }
    }
}
