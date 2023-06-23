using Apanvi.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Apanvi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] Species? species, Sizes? size, Genres? genre)
        {
            var animals = new List<Animal>()
            {
                new Animal
                {
                    Name = "jojo",
                    Description = "description",
                    Genre = Genres.Male,
                    Size = Sizes.Small,
                    Species = Species.Cat
                },
                new Animal
                {
                    Name = "kiki",
                    Description = "description",
                    Genre = Genres.Female,
                    Size = Sizes.Medium,
                    Species = Species.Dog 
                },
                new Animal
                {
                    Name = "budy",
                    Description = "description",
                    Genre = Genres.Female,
                    Size = Sizes.Medium,
                    Species = Species.Dog
                }
            };

            if (species.HasValue)
            {
                animals = animals.Where(animal => animal.Species == species).ToList();
            }
            if (size.HasValue)
            {
                animals = animals.Where(animal => animal.Size == size).ToList();
            }
            if (genre.HasValue)
            {
                animals = animals.Where(animal => animal.Genre == genre).ToList();
            }

            return Ok(animals);
        }
    }
}
