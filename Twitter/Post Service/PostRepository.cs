public class PostRepository : IPostRepository
{
    private readonly DbContext _context;

    public PostRepository(DbContext context)
    {
        _context = context;
    }

    public async Task<Post> CreatePostAsync(Post post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
        return post;
    }

    // ... other methods for getting, updating, and deleting posts
}
