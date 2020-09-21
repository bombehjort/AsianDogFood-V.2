using System;
using System.Collections.Generic;
using System.Text;
using AsianDogFood.Core.Entity;

namespace AsianDogFood.Core.DataService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);
        List<Pet> ReadAllPets();
        void PetEaten(Pet pet);
        void UpdatePetInDB(Pet pet, int typeToChange, string change);
    }
}
