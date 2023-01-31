namespace api;

public class Comment
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public Guid PostId { get; set; }
}