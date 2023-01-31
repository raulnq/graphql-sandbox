namespace api;

public class Storage
{
    public List<Post> Posts { get; set; } = new List<Post>();

    public List<Comment> Comments { get; set; } = new List<Comment>();

    public List<Author> Authors { get; set; } = new List<Author>();
}
