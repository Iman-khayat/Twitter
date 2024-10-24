public class LikeDbContext : DbContext
{
    public LikeDbContext(DbContextOptions<LikeDbContext> options) : base(options) { }

    public DbSet<Like> Likes { get; set; }
}

public class Like
{
    public int Id { get; set; }
    public string TweetId { get; set; }
    public string UserId { get; set; }
}
