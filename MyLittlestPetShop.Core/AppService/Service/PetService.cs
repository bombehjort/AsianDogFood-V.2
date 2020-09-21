using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using AsianDogFood.Core.DataService;
using AsianDogFood.Core.Entity;

namespace AsianDogFood.Core.AppService.Service
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepo;

        public PetService(IPetRepository petRepo)
        {
            _petRepo = petRepo;
        }

        public Pet NewPet(string description, string name, int type, DateTime birthdate, string color, string previousOwner, double price)
        {
            var pet = new Pet()
            {
                Description = description,
                Name = name,
                Birthdate = birthdate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            switch (type)
            {
                case 1:
                    pet.PetType = PetType.Dog;
                    break;
                case 2:
                    pet.PetType = PetType.Cat;
                    break;
            }
            return pet;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepo.ReadAllPets();
        }

        public void RemovePet(Pet pet)
        {
            _petRepo.PetEaten(pet);
        }

        public void UpdatePet(Pet pet, int typeToChange, string change)
        {
            _petRepo.UpdatePetInDB(pet, typeToChange, change);
        }
    }
}
