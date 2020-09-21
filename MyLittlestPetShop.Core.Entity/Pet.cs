using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AsianDogFood.Core.Entity
{
    public enum PetType
    {
        GoldenRetriever,
        Dobberman,
        Raccoon,
        Phinx,
        Shiba,
        Apple,
        Mosquito,
        Dog,
        Cat
    }
    public class Pet
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public PetType PetType { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime? SoldDate { get; set; }
        public string Color { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }
    }
}
