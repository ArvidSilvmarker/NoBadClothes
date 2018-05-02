using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoBadClothes
{
    public class Weather
    {
        public int Id { get; set; }
        public Station Station { get; set; }
        public double Temperature { get; set; } //t - mäts i grader Celcius med en decimal.
        public int WindDirection { get; set; } //wd - mäts i grader
        public double WindSpeed { get; set; } //ws - mäts i sekundmeter med en decimal
        public double WindGust { get; set; } //gust - mäts sekundmeter med en decimal
        public PrecipationCategory PrecipationCategory { get; set; }
        public WeatherSymbol WeatherSymbol { get; set; }
        public double PrecipationMean { get; set; } //pmean - mäts i mm/h med en decimal.



    }

    public enum PrecipationCategory
    {
        NoPrecipitation = 0,
        Snow = 1,
        SnowAndRain = 2,
        Rain = 3,
        Drizzle = 4,
        FreezingRain = 5,
        FreezingDrizzle = 6
    }

    public enum WeatherSymbol
    {
        ClearSky = 1,
        NearlyClearSky = 2,
        VariableCloudiness = 3,
        HalfclearSky = 4,
        CloudySky = 5,
        Overcast = 6,
        Fog = 7,
        LightRainShowers = 8,
        ModerateRainShowers = 9,
        HeavyRainShowers = 10,
        Thunderstorm = 11,
        LightSleetShowers = 12,
        ModerateSleetShowers = 13,
        HeavySleetShowers = 14,
        LightSnowShowers = 15,
        ModerateSnowShowers = 16,
        HeavySnowShowers = 17,
        LightRain = 18,
        ModerateRain = 19,
        HeavyRain = 20,
        Thunder = 21,
        LightSleet = 22,
        ModerateSleet = 23,
        HeavySleet = 24,
        LightSnowfall = 25,
        ModerateSnowfall = 26,
        HeavySnowfall = 27
    }
}
