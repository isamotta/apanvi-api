using Apanvi.Api.Models;
using Apanvi.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Apanvi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        [HttpGet]
        public IActionResult GetAnimals([FromQuery] Species? species = null, [FromQuery] Sizes? size = null, [FromQuery] Genres? genre = null)
        {
            var animals = _animalRepository.GetAll(species, size, genre);

            return Ok(animals);
        }
    }
}
