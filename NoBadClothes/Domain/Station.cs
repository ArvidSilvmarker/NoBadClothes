using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoBadClothes
{

    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime ReferenceTime { get; set; }
        public List<Weather> WeatherForecast { get; set; } = new List<Weather>();
    }

}
