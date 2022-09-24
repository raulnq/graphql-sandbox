namespace api;

public class PostQueries
{
    public List<Post> GetPosts([Service] Storage storage)
    {
        return storage.Posts;
    }

    public Post? GetPost(Guid id, [Service] Storage storage)
    {
        return storage.Posts.FirstOrDefault(post=>post.Id==id);
    }
}
