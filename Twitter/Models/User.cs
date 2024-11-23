public class Post
{
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation property to the User entity (optional)
    public User User { get; set; }
}