namespace api;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public List<Comment> Comments { get; set; }
    public Author Author { get; set; }
    public Guid AuthorId { get; set; }
}
