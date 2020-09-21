using System;
using System.Collections.Generic;
using System.Text;
using AsianDogFood.Core.DataService;
using AsianDogFood.Core.Entity;

namespace AsianDogFood.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {

        public Pet Create(Pet pet)
        {
            return PetDatabase.Create(pet);
        }

        public List<Pet> ReadAllPets()
        {
            return PetDatabase.GetAllPets();
        }

        public void PetEaten(Pet pet)
        {
            PetDatabase.ServePet(pet);
        }

        public void UpdatePetInDB(Pet pet, int typeToChange, string change)
        {
            PetDatabase.UpdatePetInDB(pet, typeToChange, change);
        }
    }
}
