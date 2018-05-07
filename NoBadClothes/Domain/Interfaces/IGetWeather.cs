using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoBadClothes.Domain.Interfaces
{
    interface IGetWeather
    {
        List<Station> GetForecastTopTenCities();
        Station GetForecast(Station station);
        List<Station> GetForecasts(List<Station> stations);
    }
}
