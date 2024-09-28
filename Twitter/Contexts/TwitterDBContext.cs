using Microsoft.EntityFrameworkCore;

public class TwitterDBContext: DbContext
{
    public TwitterDBContext(DbContextOptions<TwitterDBContext>options):
    base(options){ }

    public DbSet<User>Users{get;set;}
    public DbSet<Post>Posts{get;set;}
    public DbSet<Follower>Followers{get;set;}

}