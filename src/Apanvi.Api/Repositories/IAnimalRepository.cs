using Apanvi.Api.Models;

namespace Apanvi.Api.Repositories
{
    public interface IAnimalRepository
    {
        List<Animal> GetAll(Species? species = null, Sizes? size = null, Genres? genre = null);
    }
}
