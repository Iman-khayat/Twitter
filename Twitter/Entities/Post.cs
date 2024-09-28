public class Post 
{
    public int Id {get; set;}
    public string content {get; set;}
    public int UserId {get; set;}
    public DateTime CreateAt {get; set;}
    public User User {get; set;}

}