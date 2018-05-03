using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoBadClothes.Domain
{
    public class ClothingParameters
    {
        public int Temperature { get; set; }
        public PrecipationCategory Precipation { get; set; }
    }
}
