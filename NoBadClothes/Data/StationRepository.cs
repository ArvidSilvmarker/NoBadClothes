using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoBadClothes.Data
{
    public class StationRepository
    {
        private NoBadContext context = new NoBadContext();

        public void AddStations(List<Station> topTen)
        {
            using (context)
            {
                context.Stations.AddRange(topTen);
                context.SaveChanges();
            }

        }

        public Station GetStation(string cityName)
        {
            return context.Stations.FirstOrDefault(s => s.Name == cityName);
        }
    }
}
