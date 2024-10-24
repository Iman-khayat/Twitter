public class LikeServiceTests
{
    private readonly LikeService _likeService;
    private readonly Mock<ILikeRepository> _likeRepositoryMock;

    public LikeServiceTests()
    {
        _likeRepositoryMock = new Mock<ILikeRepository>();
        _likeService = new LikeService(_likeRepositoryMock.Object);
    }

    [Fact]
    public async Task LikeTweet_ShouldReturnTrue_WhenLikeIsSuccessful()
    {
        // Arrange
        var likeDto = new LikeDto { TweetId = "123", UserId = "user1" };
        _likeRepositoryMock.Setup(repo => repo.AddLikeAsync(It.IsAny<Like>()))
                           .ReturnsAsync(true);

        // Act
        var result = await _likeService.LikeTweet(likeDto);

        // Assert
        Assert.True(result);
        _likeRepositoryMock.Verify(repo => repo.AddLikeAsync(It.IsAny<Like>()), Times.Once);
    }
}
