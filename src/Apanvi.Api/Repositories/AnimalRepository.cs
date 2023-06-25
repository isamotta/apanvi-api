using Apanvi.Api.Models;
using System.Collections.Concurrent;

namespace Apanvi.Api.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private ConcurrentBag<Animal> _animalsDB = new ConcurrentBag<Animal>();

        public AnimalRepository()
        {
            _animalsDB.Add(new Animal
            {
                Name = "jojo",
                Description = "description",
                Genre = Genres.Male,
                Size = Sizes.Small,
                Species = Species.Cat
            });
            _animalsDB.Add(new Animal
            {
                Name = "kiki",
                Description = "description",
                Genre = Genres.Female,
                Size = Sizes.Medium,
                Species = Species.Dog
            });
            _animalsDB.Add(new Animal
            {
                Name = "budy",
                Description = "description",
                Genre = Genres.Female,
                Size = Sizes.Medium,
                Species = Species.Dog
            });
        }

        public List<Animal> GetAll(Species? species = null, Sizes? size = null, Genres? genre = null)
        {
            var animals = _animalsDB.ToList();

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

            return animals;
        }
    }
}
