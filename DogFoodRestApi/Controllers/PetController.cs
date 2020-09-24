using System.Collections.Generic;
using AsianDogFood.Core.AppService;
using AsianDogFood.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace DogFoodRestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetController : ControllerBase
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

        [HttpGet("{Id}")]
        public ActionResult<Pet> Get(int Id)
        {
            return _petService.GetPetById(Id);
        }
       
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if(string.IsNullOrEmpty(pet.Name))
            {
                return StatusCode(400, "Name is required to create new pet");
            }
            return _petService.CreatePet(pet);
        }

        [HttpPut("{Id}")]
        public ActionResult<Pet> Put(int Id, [FromBody] Pet pet)
        {
            if (Id < 1 || Id != pet.Id)
            {
                return BadRequest("Parameter Id and Pet Id must be the same");
            }
            
            return Ok(_petService.UpdatePet(pet));
        }

        [HttpDelete("{Id}")]
        public ActionResult<Pet>Delete(int Id)
        {
            var pet = _petService.RemovePet(Id);
            if (pet == null)
            {
                return StatusCode(404, "could not find Pet with Id:"+Id);
            }

            return Ok($"Pet with Id: {Id} was Eaten");
        }
    }
}
