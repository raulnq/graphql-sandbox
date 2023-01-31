namespace api;

public class CommentsQueries
{
    public async Task<List<Comment>> GetComments([Parent] Post post, CommentGroupedDataLoader loader)
    {
        return (await loader.LoadAsync(post.Id)).ToList();
    }
}
