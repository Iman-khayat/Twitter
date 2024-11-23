public class FeedService : IFeedService
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public FeedService(IPostRepository postRepository, IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Post>> GetUserFeedAsync(string userId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);
        var followingUserIds = user.Followings.Select(f => f.FollowingUserId);

        var posts = await _postRepository.GetPostsByUsersAsync(followingUserIds);

        // Implement logic to sort posts based on recency or other criteria
        return posts.OrderByDescending(p => p.CreatedAt);
    }
}