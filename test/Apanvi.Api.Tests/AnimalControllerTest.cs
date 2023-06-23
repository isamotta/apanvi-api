using Apanvi.Api.Controllers;
using Apanvi.Api.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Apanvi.Api.Tests
{
    public class AnimalControllerTest
    {
        [Fact]
        public void GetAnimals_WhenNoFilterApplied_ThenReturnAllAnimals()
        {
            // Arrange
            var sut = new AnimalController();

            // Act
            var response = sut.GetAnimals();

            // Assert
            var okObjectResult = response.Should().BeOfType<OkObjectResult>().Subject;
            var animalsResponse = okObjectResult.Value.Should().BeAssignableTo<List<Animal>>().Subject;

            animalsResponse.Should().HaveCount(3);
            animalsResponse.Should().BeEquivalentTo(AllAnimals());
        }

        [Theory]
        [InlineData(Sizes.Small)]
        [InlineData(Sizes.Medium)]
        [InlineData(Sizes.Large)]
        public void GetAnimals_WhenFilteredBySize_ThenReturnAnimals(Sizes size)
        {
            // Arrange
            var sut = new AnimalController();

            // Act
            var response = sut.GetAnimals(size: size);

            // Assert
            var okObjectResult = response.Should().BeOfType<OkObjectResult>().Subject;
            var animalResponse = okObjectResult.Value.Should().BeAssignableTo<List<Animal>>().Subject;

            var allWithSize = AllWithSize(size);
            animalResponse.Should().HaveCount(allWithSize.Count);
            animalResponse.Should().BeEquivalentTo(allWithSize);
        }

        [Theory]
        [InlineData(Species.Dog)]
        [InlineData(Species.Cat)]
        public void GetAnimals_WhenFilteredBySpecies_ThenReturnAnimals(Species species)
        {
            // Arrange
            var sut = new AnimalController();

            // Act 
            var response = sut.GetAnimals(species);

            // Assert
            var okObjectResult = response.Should().BeOfType<OkObjectResult>().Subject;
            var animalResponse = okObjectResult.Value.Should().BeAssignableTo<List<Animal>>().Subject;

            var allWithSpecies = AllWithSpecies(species);
            animalResponse.Should().HaveCount(allWithSpecies.Count);
            animalResponse.Should().BeEquivalentTo(allWithSpecies);
        }

        [Theory]
        [InlineData(Genres.Female)]
        [InlineData(Genres.Male)]
        public void GetAnimals_WhenFilteredByGenre_ThenReturnAnimals(Genres genre)
        {
            // Arrange
            var sut = new AnimalController();

            // Act 
            var response = sut.GetAnimals(genre: genre);

            // Assert
            var okObjectResult = response.Should().BeOfType<OkObjectResult>().Subject;
            var animalResponse = okObjectResult.Value.Should().BeAssignableTo<List<Animal>>().Subject;

            var allWithGenre = AllWithGenre(genre);
            animalResponse.Should().HaveCount(allWithGenre.Count);
            animalResponse.Should().BeEquivalentTo(allWithGenre);

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
            return AllAnimals().Where(animal =>  animal.Size == size).ToList();
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