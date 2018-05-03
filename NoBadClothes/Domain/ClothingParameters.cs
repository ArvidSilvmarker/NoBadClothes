using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoBadClothes.Domain
{
    public class ClothingParameters
    {
        public double Temperature { get; set; }
        public PrecipationCategory PrecipationCategory { get; set; }
        public double Precipation { get; set; }
    }
}
