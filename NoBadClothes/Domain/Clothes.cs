using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoBadClothes.Domain
{
    public enum ClothesLayer
    {
        BaseLayer = 1,
        MidLayer = 2,
        OutherLayer = 3
    }

    public enum ClothesPlasement
    {
        Other = 0,
        Head = 1,
        Neck = 2,
        UpperBody = 3,
        Hands = 4,
        LowerBody = 5,
        Feet = 6
    }

    public class Clothes
    {
        public string Name { get; set; }
        //public bool PutOnGarment { get; set; }
        public ClothesPlasement ClothesPlasement { get; set; }
        public ClothesLayer ClothesLayer { get; set; }

    }

    public class ClothesSuggestion
    {
        public Clothes Clothes { get; set; }
        public bool InBag { get; set; }

    }


}
