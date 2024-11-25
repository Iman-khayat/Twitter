using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Twitter.Controllers;
using Twitter.Services;
using Twitter.DTOs;

namespace Twitter.Tests.Controllers
{
    public class UserControllerTests
    {
        [Fact]
        public async Task RegisterUser_ValidRequest_ReturnsOk()
        {
            // Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(s => s.RegisterUserAsync(It.IsAny<User>()))
                .ReturnsAsync(true);

            var controller = new UserController(mockUserService.Object);
            var registrationDto = new UserRegistrationDto { ... };

            // Act
            var result = await controller.RegisterUser(registrationDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True((bool)okResult.Value);
        }

       
    }
}