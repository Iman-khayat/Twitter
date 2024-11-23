[ApiController]
[Route("api/[controller]")]
public class FeedController : ControllerBase
{
    private readonly IFeedService _feedService;

    public FeedController(IFeedService feedService)
    {
        _feedService = feedService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetUserFeed(string userId)
    {
        var posts = await _feedService.GetUserFeedAsync(userId);
        return Ok(posts.Select(p => new PostDto
        {
            // Map Post properties to PostDto
        }));
    }
}