public class NotificationService
{
    private readonly NotificationDbContext _context;

    public NotificationService(NotificationDbContext context)
    {
        _context = context;
        // Set up the listener for RabbitMQ/Service Bus here
    }

    public async Task OnLikeEventReceived(string tweetId, string userId)
    {
        var message = $"User {userId} liked your tweet {tweetId}.";
        var notification = new Notification
        {
            UserId = userId,
            Message = message
        };

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();
    }
    
    // RabbitMQ or Service Bus listener logic here (consume events)
}
