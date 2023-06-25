using Apanvi.Api.Controllers;
using Apanvi.Api.Models;
using Apanvi.Api.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Apanvi.Api.Tests.Controllers
{
    public class AnimalControllerTest
    {
        [Theory]
        [InlineData(Species.Dog, Sizes.Small, Genres.Female)]
        public void GetAnimals_WhenNoFilterApplied_ThenReturnAllAnimals(Species species, Sizes size, Genres genre)
        {
            // Arrange
            var animals = new List<Animal>()
            {
                new Animal()
            };
            var repositoryMock = new Mock<IAnimalRepository>();
            repositoryMock
                .Setup(p => p.GetAll(species, size, genre))
                .Returns(animals);

            var sut = new AnimalController(repositoryMock.Object);

            // Act
            var response = sut.GetAnimals(species, size, genre);

            // Assert
            var okObjectResult = response.Should().BeOfType<OkObjectResult>().Subject;
            var animalsResponse = okObjectResult.Value.Should().BeAssignableTo<List<Animal>>().Subject;

            animalsResponse.Should().BeSameAs(animals);
            repositoryMock.Verify(p => p.GetAll(It.IsAny<Species?>(), It.IsAny<Sizes?>(), It.IsAny<Genres?>()), Times.Once);
            repositoryMock.VerifyNoOtherCalls();
        }
    }
}