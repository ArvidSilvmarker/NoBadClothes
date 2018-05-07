using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoBadClothes.Domain
{
    public static class ClothesPackages
    {
        public static List<string> WinterClothes { get; set; } = new List<string> { "Vinterjacka", "Vantar", "Mössa", "Vinterstövlar" };
        public static List<string> RainClothes { get; set; } = new List<string> {"Regnjacka", "Stövlar"};
        public static List<string> SpringClothes { get; set; } = new List<string> {"Sommarjacka", "Gympaskor"};
        public static List<string> SummerShoes { get; set; } = new List<string> {"Sandaler"};
        public static List<string> BaseShoes { get; set; } = new List<string> {"Gympaskor"};
        public static List<string> BaseClothes { get; set; } = new List<string> {"Långbyxor", "T-tröja", "Tröja"};
        public static List<string> SummerClothes { get; set; } = new List<string> {"Shorts", "T-tröja"};
    }
}
