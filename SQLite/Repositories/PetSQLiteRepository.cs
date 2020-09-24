using System.Collections.Generic;
using AsianDogFood.Core.DataService;
using AsianDogFood.Core.Entity;

namespace SQLite.Repositories
{
    public class PetSQLiteRepository : IPetRepository
    {
        private readonly PetAppDBContext _ctx;
        public PetSQLiteRepository(PetAppDBContext ctx)
        {
            _ctx = ctx;
        }
        public Pet Create(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public List<Pet> ReadAllPets()
        {
            throw new System.NotImplementedException();
        }

        public void PetEaten(Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePetInDB(Pet pet, int typeToChange, string change)
        {
            throw new System.NotImplementedException();
        }

        public Pet GetPetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}