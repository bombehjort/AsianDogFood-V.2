using AsianDogFood.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace AsianDogFood.Core.AppService
{
    public class IPetTypeService
    {
        public bool AddNewPetType(PetType.PetType type);
        public List<PetType> GetAllPetTypes();
        public PetType GetPetType(int id);
        public PetType DeletePetType(int id);
        public bool UpdatePetType(PetType type);
    }
}