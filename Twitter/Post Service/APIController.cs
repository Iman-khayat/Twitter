[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDto postDto)
    {
        // Map postDto to Post entity and call PostService.CreatePostAsync
    }

    // ... other endpoints for getting, updating, and deleting posts
}