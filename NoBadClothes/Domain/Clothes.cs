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

        public List<Clothes> PossibleClothes()
        {
            List<Clothes> possibleClothes = new List<Clothes>();
            var raincoat = new Clothes {ClothesLayer = ClothesLayer.OutherLayer, ClothesPlasement = ClothesPlasement.UpperBody, Name = "Regnjacka"};
            possibleClothes.Add(raincoat);
            var winterjacket = new Clothes { ClothesLayer = ClothesLayer.OutherLayer, ClothesPlasement = ClothesPlasement.UpperBody, Name = "Vinterjacka" };
            possibleClothes.Add(raincoat);
            var summerjacket = new Clothes { ClothesLayer = ClothesLayer.OutherLayer, ClothesPlasement = ClothesPlasement.UpperBody, Name = "Sommarjacka" };
            possibleClothes.Add(summerjacket);
            var mittens = new Clothes { ClothesLayer = ClothesLayer.OutherLayer, ClothesPlasement = ClothesPlasement.Hands, Name = "Vantar" };
            possibleClothes.Add(mittens);
            var hat = new Clothes { ClothesLayer = ClothesLayer.OutherLayer, ClothesPlasement = ClothesPlasement.Head, Name = "Mössa" };
            possibleClothes.Add(hat);

            var winterboots = new Clothes { ClothesLayer = ClothesLayer.OutherLayer, ClothesPlasement = ClothesPlasement.Feet, Name = "Vinterstövlar" };
            possibleClothes.Add(winterboots);
            var boots = new Clothes { ClothesLayer = ClothesLayer.OutherLayer, ClothesPlasement = ClothesPlasement.Feet, Name = "Stövlar" };
            possibleClothes.Add(boots);
            var sneakers = new Clothes { ClothesLayer = ClothesLayer.OutherLayer, ClothesPlasement = ClothesPlasement.Feet, Name = "Gympaskor" };
            possibleClothes.Add(sneakers);
            var sandals = new Clothes { ClothesLayer = ClothesLayer.OutherLayer, ClothesPlasement = ClothesPlasement.Feet, Name = "Sandaler" };
            possibleClothes.Add(sandals);



            var pants = new Clothes { ClothesLayer = ClothesLayer.MidLayer, ClothesPlasement = ClothesPlasement.LowerBody, Name = "Långbyxor"};
            possibleClothes.Add(pants);
            var shorts = new Clothes { ClothesLayer = ClothesLayer.MidLayer, ClothesPlasement = ClothesPlasement.LowerBody, Name = "Shorts" };
            possibleClothes.Add(shorts);
            var sweater = new Clothes { ClothesLayer = ClothesLayer.MidLayer, ClothesPlasement = ClothesPlasement.UpperBody, Name = "Tröja" };
            possibleClothes.Add(sweater);
            var tshirt = new Clothes { ClothesLayer = ClothesLayer.MidLayer, ClothesPlasement = ClothesPlasement.UpperBody, Name = "T-tröja" };
            possibleClothes.Add(tshirt);

            return possibleClothes;
        }

    }

    public class ClothesSuggestion
    {
        public Clothes Clothes { get; set; }
        public bool InBag { get; set; }

    }

}
