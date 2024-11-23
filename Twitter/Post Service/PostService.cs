public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;

    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        return await _postRepository.CreatePostAsync(post);
    }

    // ... other methods for getting, updating, and deleting posts
}