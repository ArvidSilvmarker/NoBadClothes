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

        public Weather YesterdayWeather { get; set; }
        public Weather TodayWeather { get; set; }
        public Weather MorningWeather { get; set; }
        public Weather NoonWeather { get; set; }
        public Weather AfternoonWeather { get; set; }
        public Weather EveningWeather { get; set; }
    }

}
