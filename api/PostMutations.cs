namespace api;

public record AddPostInput(string Title, string Body);

public record EditPostInput(Guid Id, string Body);

public record RemovePostInput(Guid Id);

public record AddPostPayload(Post post);

public record RemovePostPayload(Post post);

public record EditPostPayload(Post post);

public class PostMutations
{
    public AddPostPayload AddPost(AddPostInput input, [Service] Storage storage)
    {
        var post = new Post() { Id = Guid.NewGuid(), Body = input.Body, Title = input.Title };
        storage.Posts.Add(post);
        return new AddPostPayload(post);
    }

    public RemovePostPayload RemovePost(RemovePostInput input, [Service] Storage storage)
    {
        var post = storage.Posts.Single(post => post.Id == input.Id);
        storage.Posts.Remove(post);
        return new RemovePostPayload(post);
    }

    public EditPostPayload? EditPost(EditPostInput input, [Service] Storage storage)
    {
        var post = storage.Posts.Single(post => post.Id == input.Id);
        post.Body = input.Body;
        return new EditPostPayload(post);
    }
}
