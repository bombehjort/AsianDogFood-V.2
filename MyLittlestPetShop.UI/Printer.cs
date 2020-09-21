using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using AsianDogFood.Core.AppService;
using AsianDogFood.Core.Entity;
using AsianDogFood.Infrastructure.Data;

namespace AsianDogFood.UI
{
    public class Printer
    {
        private IPetService _petService;
        private int _selection = 0;
        private int _showcase = 0;

        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        private string[] menuItems = {
            "Showcase",
            "All current Pets",
            "Search for Pet",
            "Procure new pet",
            "Season and spice up the pet differently",
            "Get the pet served for you! Bon Appetit!",
            "Leave"
        };


        public void ResetStage()
        {
            _selection = 0; // check if necessary
            PrintMainMenu();
            _selection = SelectedNumber(1,7);
            LoadNextSceneFromMain(_selection);
        }

        public void PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Ni Hao! Come in, come in! See what pets for dinner we have in my shop! ");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("What pet do you want to feast on today?\n");

            PrintMenu(menuItems);
        }

        public void PrintMenu(string[] options)
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{(i + 1)} : {options[i]}");
            }
        }

        public void LoadNextSceneFromMain(int selection)
        {
            switch (selection)
            {
                case 1:
                    Console.Clear();
                    if (_showcase != 0)
                    {
                        Console.WriteLine("Do you want to continue from where we left off?");
                        if (!CheckIfYesOrNo())
                        {
                            _showcase = 0;
                            Console.Clear();
                        }
                    }
                    PrintShowcase(_showcase);
                    break;

                case 2:
                    Console.Clear();
                    int petNumber = 1;
                    foreach (var pet in PetDatabase.AllPets)
                    {
                        Console.WriteLine($"{petNumber}:\nName: {pet.Name}\nSpecies: {pet.PetType}\n");
                        petNumber++;
                    }
                    Console.WriteLine("\nPress ENTER to return");
                    Console.ReadLine();
                    ResetStage();
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Would you like to search with Species or search by price?\n1: Species\n2: Price");
                    SearchForPet(SelectedNumber(1,2));
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine(
                        "Dog or cat? what suits your taste?\n" +
                        "1: Dog\n" +
                        "2: Cat\n" +
                        "3: Nevermind");
                    int tempType = SelectedNumber(1, 3);
                    if (tempType == 3)
                    {
                        ResetStage();
                    }
                    Console.Clear();
                    Console.WriteLine("Name your dinner!");
                    string name = Console.ReadLine();
                    Console.WriteLine("\nWhat colors does it have? The orange one taste best!");
                    string color = Console.ReadLine();
                    Console.WriteLine("\nDescribe your delicious dinner");
                    string description = Console.ReadLine();
                    Console.WriteLine("\n What's the price for your food?");
                    int price = 0;
                    while (!int.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Please write a number");
                    }
                    Pet newPet = _petService.NewPet(description, name, tempType, DateTime.Now, color, "You", price);
                    _petService.CreatePet(newPet);
                    Console.WriteLine("\nA new pet has been procured. Time to feast! ");
                    Console.WriteLine("\nPress ENTER to return");
                    Console.ReadLine();
                    ResetStage();
                    break;

                case 5:
                    Console.Clear();
                    int numberOfChange = 1;
                    Console.WriteLine("Which Animal would you like to change the information for?\n");
                    foreach (var petToChange in PetDatabase.AllPets)
                    {
                        Console.WriteLine($"{numberOfChange}: {petToChange.Name}");
                        numberOfChange++;
                    }
                    Pet petToUpdate = PetDatabase.AllPets[SelectedNumber(1, numberOfChange - 1) - 1];
                    Console.Clear();
                    Console.WriteLine("What would you like to change?");

                    Console.WriteLine($"1 Name: {petToUpdate.Name}");
                    Console.WriteLine($"2 Description: {petToUpdate.Description}");
                    Console.WriteLine($"3 Color: {petToUpdate.Color}");
                    Console.WriteLine($"4 Previous Owner: {petToUpdate.PreviousOwner}");
                    Console.WriteLine($"5 Selling price: {petToUpdate.Price}\n\n");
                    int variableToChange = SelectedNumber(1, 5);
                    Console.Clear();
                    switch (variableToChange)
                    {
                        case 1:
                            Console.WriteLine("What would you like to change the name to?");
                            petToUpdate.Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("What would you like the description to be?");
                            petToUpdate.Description = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("What is the new color of the animal?");
                            petToUpdate.Color = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Who is the previous owner?");
                            petToUpdate.PreviousOwner = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("What is the new price for the animal?");
                            int o = 0;
                            while (!int.TryParse(Console.ReadLine(), out o))
                            {
                                Console.WriteLine("Please write a number");
                            }
                            petToUpdate.Price = o;
                            break;
                    }
                    Console.WriteLine("Change has been made.\nPress ENTER to return");
                    Console.ReadLine();
                    ResetStage();
                    break;

                case 6:
                    Console.Clear();
                    int numberOfDeath = 1;
                    Console.WriteLine("Are you sure you want to eat this one? We can bring out a different one, on a plate.");
                    foreach (var PetToEat in PetDatabase.AllPets)
                    {
                        Console.WriteLine($"{numberOfDeath}: {PetToEat.Name}");
                        numberOfDeath++;
                    }
                    _petService.RemovePet(PetDatabase.AllPets[SelectedNumber(1, numberOfDeath-1)-1]);
                    Console.WriteLine("\nBon Appetit!");
                    Console.WriteLine("\nPress ENTER to return");
                    Console.ReadLine();
                    ResetStage();
                    break;

                case 7:
                    Console.Clear();
                    break;
            }
        }

        private void PrintShowcase(int currentShowcase)
        {
            while (true)
            {
                foreach (var pet in PetDatabase.AllPets)
                {
                    if (pet.Id == _showcase+1)
                    {
                        PrintAllAnimalDetails(pet);
                        break;
                    }
                }
                Console.WriteLine("Want to see what else we have to offer?");
                if (CheckIfYesOrNo())
                {
                    Console.Clear();
                    currentShowcase = _showcase++;
                    continue;
                }
                else
                {
                    ResetStage();
                }
            }
        }

        private bool CheckIfYesOrNo()
        {
            Console.WriteLine("Yes/No?");
            string temp = Console.ReadLine().ToLower();
            while (true)
            {
                if (temp == "yes")
                {
                    return true;
                }
                else if (temp == "no")
                {
                    return false;
                }
                Console.WriteLine("Please answer with Yes or No");
                temp = Console.ReadLine();
            }
        }

        private int SelectedNumber(int para1, int para2)
        {
            int selectedItem = 0;
            while (!int.TryParse(Console.ReadLine(), out selectedItem)
                   || selectedItem < para1-1
                   || selectedItem > para2+1)
            {
                Console.WriteLine($"Please select a number between {para1} and {para2}");
            }
            return selectedItem;
        }

        private void PrintAllAnimalDetails(Pet pet)
        {
            Console.WriteLine($"Name: {pet.Name}");
            Console.WriteLine($"Species: {pet.PetType}");
            Console.WriteLine($"Description: {pet.Description}\n");
            Console.WriteLine($"Color: {pet.Color}");
            Console.WriteLine($"Birthdate: {pet.Birthdate}");
            Console.WriteLine($"Previous Owner: {pet.PreviousOwner}");
            Console.WriteLine($"Selling price: {pet.Price}\n\n");
        }

        private void SearchForPet(int searchNumber)
        {
            Console.Clear();
            if (searchNumber == 1)
            {
                int temp = 1;
                Console.WriteLine("Please select from the following species: ");
                foreach (PetType species in (PetType[]) Enum.GetValues(typeof(PetType)))
                {
                    Console.WriteLine($"{temp}: {species}");
                    temp++;
                }
                foreach (var sortedPets in SortListOfPetsByType(SelectedNumber(1, temp - 1)))
                {
                    PrintAllAnimalDetails(sortedPets);
                }
                Console.WriteLine("Press ENTER to return");
                Console.ReadLine();
                ResetStage();
            }
            else
            {
                Console.WriteLine("How do you want to sort this?\n1: 5 cheapest options\n2: All pets cheapest to most expensive\n3: All pets most expensive to cheapest");
                int SelectedSearch = SelectedNumber(1,3);
                Console.Clear();
                switch (SelectedSearch)
                {
                    case 1:
                        Console.WriteLine("These are the 5 cheapest currently available animals:");
                        List<Pet> sortedListOf5 = SortListByCheapestPrice();
                        for (int i = 0; i < 5; i++)
                        {
                            PrintAllAnimalDetails(sortedListOf5[i]);
                        }
                        break;
                    case 2:
                        Console.WriteLine("These are the 5 cheapest currently available animals:");
                        List<Pet> sortedListOfCheap = SortListByCheapestPrice();
                        for (int i = 0; i < sortedListOfCheap.Count; i++)
                        {
                            PrintAllAnimalDetails(sortedListOfCheap[i]);
                        }
                        break;
                    case 3:
                        Console.WriteLine("These are the 5 cheapest currently available animals:");
                        List<Pet> sortedListOfExpensive = SortListByMostExpensivePrice();
                        for (int i = 0; i < sortedListOfExpensive.Count; i++)
                        {
                            PrintAllAnimalDetails(sortedListOfExpensive[i]);
                        }
                        break;
                }
                Console.WriteLine("Press ENTER to return");
                Console.ReadLine();
                ResetStage();
            }
        }

        private List<Pet> SortListOfPetsByType(int type)
        {
            List<Pet> sortedList = new List<Pet>();
            switch (type)
            {
                case 1:
                    foreach (var petToSort in PetDatabase.AllPets)
                    {
                        if (petToSort.PetType == PetType.GoldenRetriever)
                        {
                            sortedList.Add(petToSort);
                        }
                    }
                    break;
                case 2:
                    foreach (var petToSort in PetDatabase.AllPets)
                    {
                        if (petToSort.PetType == PetType.Dobberman)
                        {
                            sortedList.Add(petToSort);
                        }
                    }
                    break;
                case 3:
                    foreach (var petToSort in PetDatabase.AllPets)
                    {
                        if (petToSort.PetType == PetType.Raccoon)
                        {
                            sortedList.Add(petToSort);
                        }
                    }
                    break;
                case 4:
                    foreach (var petToSort in PetDatabase.AllPets)
                    {
                        if (petToSort.PetType == PetType.Phinx)
                        {
                            sortedList.Add(petToSort);
                        }
                    }
                    break;
                case 5:
                    foreach (var petToSort in PetDatabase.AllPets)
                    {
                        if (petToSort.PetType == PetType.Shiba)
                        {
                            sortedList.Add(petToSort);
                        }
                    }
                    break;
                case 6:
                    foreach (var petToSort in PetDatabase.AllPets)
                    {
                        if (petToSort.PetType == PetType.Apple)
                        {
                            sortedList.Add(petToSort);
                        }
                    }
                    break;
                case 7:
                    foreach (var petToSort in PetDatabase.AllPets)
                    {
                        if (petToSort.PetType == PetType.Mosquito)
                        {
                            sortedList.Add(petToSort);
                        }
                    }
                    break;
                case 8:
                    foreach (var petToSort in PetDatabase.AllPets)
                    {
                        if (petToSort.PetType == PetType.Dog)
                        {
                            sortedList.Add(petToSort);
                        }
                    }
                    break;
                case 9:
                    foreach (var petToSort in PetDatabase.AllPets)
                    {
                        if (petToSort.PetType == PetType.Cat)
                        {
                            sortedList.Add(petToSort);
                        }
                    }
                    break;
            }
            return sortedList;
        }

        private List<Pet> SortListByCheapestPrice()
        {
            List<Pet> sortedList = PetDatabase.AllPets;
            sortedList.Sort(
                (p1, p2) => p1.Price.CompareTo(p2.Price));
            return sortedList;
        }
        private List<Pet> SortListByMostExpensivePrice()
        {
            List<Pet> sortedList = PetDatabase.AllPets;
            sortedList.Sort(
                (p1, p2) => p2.Price.CompareTo(p1.Price));
            return sortedList;
        }
    }
}
