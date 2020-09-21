using System;
using AsianDogFood.Core.AppService;
using AsianDogFood.Core.AppService.Service;
using AsianDogFood.Core.DataService;
using AsianDogFood.Infrastructure.Data;

namespace AsianDogFood.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
          IPetRepository petRepo = new PetRepository();
          IPetService petService = new PetService(petRepo); 
          var printer = new Printer(petService);
          PetDatabase.PopulateList();
          printer.ResetStage();
        }
    }
}
