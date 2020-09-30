using System.Collections.Generic;
using AsianDogFood.Core.DataService;
using AsianDogFood.Core.Entity;

namespace AsianDogFood.Core.AppService.Service
{
    public class PetTypeService : IPetRepository
    {
        private IPetTypeRepository _petTypeRepository;
 
        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }

        public bool AddNewPetType(PetType type)
        {
            return _petTypeRepository.AddNewPetType(type);
        }

        public Pet Create(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public PetType DeletePetType(int id)
        {
            return _petTypeRepository.DeletePetType(id);
        }

        public List<PetType> GetAllPetTypes()
        {
            return _petTypeRepository.GetAllPetTypes();
        }

        public Pet GetPetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public PetType GetPetType(int id)
        {
            return _petTypeRepository.GetPetType(id);
        }

        public void PetEaten(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> ReadAllPets()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePetInDB(Pet pet, int typeToChange, string change)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdatePetType(PetType type)
        {
            return _petTypeRepository.UpdatePetType(type);
        }
    }
}

