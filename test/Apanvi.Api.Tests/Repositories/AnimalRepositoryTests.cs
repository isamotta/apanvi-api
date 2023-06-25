using Apanvi.Api.Models;
using Apanvi.Api.Repositories;
using FluentAssertions;

namespace Apanvi.Api.Tests.Repositories
{
    public class AnimalRepositoryTests
    {
        [Fact]
        public void GetAll_WhenNoFilter_ThenReturnAll()
        {
            // Arrange
            var sut = new AnimalRepository();

            // Act
            var animals = sut.GetAll();

            // Assert
            animals.Should().HaveCount(3);
            animals.Should().BeEquivalentTo(AllAnimals());
        }

        [Theory]
        [InlineData(Genres.Male)]
        [InlineData(Genres.Female)]
        public void GetAll_WhenFilteredByGenre_ThenReturnFilteredAnimals(Genres genre)
        {
            // Arrange
            var sut = new AnimalRepository();

            // Act
            var animals = sut.GetAll(genre: genre);

            // Assert
            var animalsByGenre = AllWithGenre(genre);
            animals.Should().HaveCount(animalsByGenre.Count);
            animals.Should().BeEquivalentTo(animalsByGenre);
        }

        [Theory]
        [InlineData(Species.Cat)]
        [InlineData(Species.Dog)]
        public void GetAll_WhenFilteredBySpecies_ThenReturnFilteredAnimals(Species species)
        {
            // Arrange
            var sut = new AnimalRepository();

            // Act
            var animals = sut.GetAll(species);

            // Assert
            var animalsBySpecies = AllWithSpecies(species);
            animals.Should().HaveCount(animalsBySpecies.Count);
            animals.Should().BeEquivalentTo(animalsBySpecies);
        }

        [Theory]
        [InlineData(Sizes.Small)]
        [InlineData(Sizes.Medium)]
        [InlineData(Sizes.Large)]
        public void GetAll_WhenFilteredBySize_ThenReturnFilteredAnimals(Sizes size)
        {
            // Arrange
            var sut = new AnimalRepository();

            // Act
            var animals = sut.GetAll(size: size);

            // Assert
            var animalsBySize = AllWithSize(size);
            animals.Should().HaveCount(animalsBySize.Count);
            animals.Should().BeEquivalentTo(animalsBySize);
        }

        private List<Animal> AllWithGenre(Genres genre)
        {
            return AllAnimals().Where(animal => animal.Genre == genre).ToList();
        }

        private List<Animal> AllWithSpecies(Species species)
        {
            return AllAnimals().Where(animal => animal.Species == species).ToList();
        }

        private List<Animal> AllWithSize(Sizes size)
        {
            return AllAnimals().Where(animal => animal.Size == size).ToList();
        }

        private List<Animal> AllAnimals()
        {
            return new List<Animal>()
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
        }
    }
}
