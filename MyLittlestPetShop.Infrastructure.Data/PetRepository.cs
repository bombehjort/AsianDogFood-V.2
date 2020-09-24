using System;
using System.Collections.Generic;
using System.Text;
using AsianDogFood.Core.DataService;
using AsianDogFood.Core.Entity;

namespace AsianDogFood.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        private List<Pet> AllPets = new List<Pet>();

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
        public Pet GetPetById(int id)
        {
            var pet = AllPets.Find(pet => pet.Id == id);

            if (pet == null)
            {
                throw new KeyNotFoundException($"pet with id {pet.Id} doesnt exist");
            }

            return pet;
        }
    }
}
