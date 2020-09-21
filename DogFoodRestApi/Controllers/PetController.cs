using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsianDogFood.Core.AppService;
using AsianDogFood.Core.AppService.Service;
using AsianDogFood.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DogFoodRestApi.Controllers
{
    [ApiController]
    [Route("api/Pet")]
    public class PetController
    {
        private readonly ILogger<PetController> _logger;
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _petService.GetAllPets();
        }
    }
}
