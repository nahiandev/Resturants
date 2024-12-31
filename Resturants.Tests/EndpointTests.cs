using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Restaurants.Actions.Queries.GetResturantById;
using Restaurants.Controllers;
using Restaurants.Domains.DTOs;

namespace Resturants.Tests
{
    public class EndpointTests
    {
        private Mock<IMediator> _mediatorMock;
        private ResturantController _controller;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new ResturantController(_mediatorMock.Object);
        }

        [Test]
        public async Task TestGetResturantById()
        {
            // Arrange
            var resturantId = 3;
            var expectedResturant = new ResturantDTO
            {
                Name = "Italian Bistro",
                Description = "A cozy place for authentic Italian cuisine.",
                Category = "Italian",
                HasDelivery = true,
                PhoneNumber = "123-456-7890",
                Email = "contact@italianbistro.com",
            };

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetResturantByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResturant);

            // Act
            var result = await _controller.GetResturantById(resturantId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var actualResturant = okResult.Value as ResturantDTO;
            Assert.IsNotNull(actualResturant);

            Assert.That(actualResturant.Name, Is.EqualTo(expectedResturant.Name));
        }
    }
}