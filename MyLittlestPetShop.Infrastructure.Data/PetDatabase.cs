using System;
using System.Collections.Generic;
using System.Text;
using AsianDogFood.Core.Entity;

namespace AsianDogFood.Infrastructure.Data
{
    public static class PetDatabase
    {
        private static int _id = 1;
        public static List<Pet> AllPets;

        public static Pet Create(Pet pet)
        {
            pet.Id = _id++;
            AllPets.Add(pet);
            return pet;
        }

        public static void UpdatePetInDB(Pet pet, int typeToChange, string change)
        {
        }

        public static void ServePet(Pet pet)
        {
            try
            {
                foreach (var petToDelete in AllPets)
                {
                    if (petToDelete.Id == pet.Id)
                    {
                        AllPets.Remove(petToDelete);
                        break;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Roh UH shaggy! somethings wrong!");
            }
        }
        public static List<Pet> GetAllPets()
        {
            return AllPets;
        }

        public static void PopulateList()
        {

            Pet pet1 = new Pet()
            {
                Id = _id++,
                Name = "Meatslab",
                Description = "Very big muscle, much meat! Will taste very good!",
                PetType = PetType.Dobberman,
                Birthdate = DateTime.Now.AddYears(-5),
                Color = "Grey",
                PreviousOwner = "Stray",
                Price = 2328
            };

            Pet pet2 = new Pet()
            {
                Id = _id++,
                Name = "Bobby",
                Description = "Found this critter flattened down on the road. Will proberly taste great, with barbaque!",
                PetType = PetType.Raccoon,
                Birthdate = DateTime.Now.AddYears(-2),
                Color = "Black with brown stripes",
                PreviousOwner = "Wild animal",
                Price = 25
            };

            Pet pet3 = new Pet()
            {
                Id = _id++,
                Name = "Little John",
                Description = "Poor dog jumped after the ball, and straight into " +
                              "a electric generator. Maybe it's a bad idea to " +
                              "play baseball right beside the powerstation\n " +
                              "At least he comes pre-cooked!",
                PetType = PetType.GoldenRetriever,
                Birthdate = DateTime.Now.AddYears(-5),
                Color = "Golden",
                PreviousOwner = "Senior John",
                Price = 150
            };

            Pet pet4 = new Pet()
            {
                Id = _id++,
                Name = "Bricks",
                Description = "I had not noticed that Bricks had fallen into the soup pot, until i later coughed up a hairball!" +
                              "at least she tasted great, which i why im selling the soup! ",
                PetType = PetType.Phinx,
                Birthdate = DateTime.Now.AddYears(-10),
                Color = "Silver Fur",
                PreviousOwner = "Old Nanny",
                Price = 500
            };

            Pet pet5 = new Pet()
            {
                Id = _id++,
                Name = "Felix",
                Description = "Damn dog keeps barking, and im getting tired of it! which is why im selling him to this shop!",
                PetType = PetType.Shiba,
                Birthdate = DateTime.Now.AddYears(-12),
                Color = "Caramel colored",
                PreviousOwner = "Petite Pete",
                Price = 250
            };

           


            AllPets = new List<Pet>(){pet1,pet2,pet3,pet4,pet5};
        }

    }
}
