using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using Twitter.Data;
using Twitter.Models;
using Twitter.Repositories;

namespace Twitter.Tests.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task GetUserByUsernameAsync_UserExists_ReturnsUser()
        {
            // Arrange
            var mockContext = new Mock<DbContext>();
            mockContext.Setup(c => c.Users)
                .Returns(DbSetMock.Of(new[] { new User { Username = "testuser", Id = 1 } }));

            var repository = new UserRepository(mockContext.Object);

            // Act
            var user = await repository.GetUserByUsernameAsync("testuser");

            // Assert
            Assert.NotNull(user);
            Assert.Equal("testuser", user.Username);
        }

        // ... other test cases for user not found, database errors, etc.
    }
}