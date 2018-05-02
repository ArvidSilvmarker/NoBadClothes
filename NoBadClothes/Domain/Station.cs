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

        public Weather YesterdayWeather { get; set; } = new Weather();
        public Weather TodayWeather { get; set; } = new Weather();
        public Weather MorningWeather { get; set; } = new Weather();
        public Weather NoonWeather { get; set; } = new Weather();
        public Weather AfternoonWeather { get; set; } = new Weather();
        public Weather EveningWeather { get; set; } = new Weather();
    }

}
