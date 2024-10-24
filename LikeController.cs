[ApiController]
[Route("api/[controller]")]
public class LikeController : ControllerBase
{
    private readonly LikeDbContext _context;

    public LikeController(LikeDbContext context)
    {
        _context = context;
    }

    [HttpPost("like")]
    public async Task<IActionResult> LikeTweet([FromBody] LikeDto likeDto)
    {
        var likeExists = await _context.Likes
            .AnyAsync(l => l.TweetId == likeDto.TweetId && l.UserId == likeDto.UserId);
        if (likeExists)
        {
            return BadRequest("You already liked this tweet.");
        }

        var like = new Like
        {
            TweetId = likeDto.TweetId,
            UserId = likeDto.UserId
        };

        _context.Likes.Add(like);
        await _context.SaveChangesAsync();

        // Emit event to notification microservice (via RabbitMQ or Azure Service Bus)
        await PublishLikeEvent(likeDto.TweetId, likeDto.UserId);

        return Ok("Tweet liked.");
    }

    [HttpPost("unlike")]
    public async Task<IActionResult> UnlikeTweet([FromBody] LikeDto likeDto)
    {
        var like = await _context.Likes
            .FirstOrDefaultAsync(l => l.TweetId == likeDto.TTweetId && l.UserId == likeDto.UserId);
        if (like == null)
        {
            return NotFound("You haven't liked this tweet yet.");
        }

        _context.Likes.Remove(like);
        await _context.SaveChangesAsync();

        return Ok("Tweet unliked.");
    }

    [HttpGet("likes/{tweetId}")]
    public async Task<IActionResult> GetLikes(string tweetId)
    {
        var likeCount = await _context.Likes.CountAsync(l => l.TweetId == tweetId);
        return Ok(new { tweetId, likes = likeCount });
    }

    private async Task PublishLikeEvent(string tweetId, string userId)
    {
        // Example for RabbitMQ or Azure Service Bus communication
        // Send a message to notify the Notification Service
    }
}

public class LikeDto
{
    public string TweetId { get; set; }
    public string UserId { get; set; }
}
