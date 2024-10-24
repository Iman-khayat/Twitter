public class LikeIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
{
    private readonly HttpClient _client;

    public LikeIntegrationTests(WebApplicationFactory<Startup> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task LikeTweet_ShouldReturn201_WhenLikeIsSuccessful()
    {
        // Arrange
        var likeDto = new { TweetId = "123", UserId = "user1" };
        var content = new StringContent(JsonConvert.SerializeObject(likeDto), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/like", content);

        // Assert
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
