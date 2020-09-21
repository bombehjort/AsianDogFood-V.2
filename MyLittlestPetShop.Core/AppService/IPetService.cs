using System;
using System.Collections.Generic;
using System.Text;
using AsianDogFood.Core.Entity;

namespace AsianDogFood.Core.AppService
{
    public interface IPetService
    {
        Pet NewPet(string description, string name, int type, DateTime birthdate, string color, string previousOwner, double price);
        Pet CreatePet(Pet pet);
        List<Pet> GetAllPets();
        void RemovePet(Pet pet);
        void UpdatePet(Pet pet, int typeToChange, string change);

    }
}
