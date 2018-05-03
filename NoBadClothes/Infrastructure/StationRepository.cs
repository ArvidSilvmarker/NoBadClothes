using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NoBadClothes.Data
{
    public class StationRepository
    {
        private NoBadContext context = new NoBadContext();

        public void ClearDatabase()
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public void AddStations(List<Station> topTen)
        {
            using (var context = new NoBadContext())
            {
                context.Stations.AddRange(topTen);
                context.SaveChanges();
            }

        }

        public Station GetStation(string cityName)
        {
            return context.Stations.Include(s => s.WeatherForecast).FirstOrDefault(s => s.Name == cityName);
        }
    }
}
