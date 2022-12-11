namespace api;

public record AddPostInput(string Title, string Body);

public record EditPostInput(Guid Id, string Body);

public record RemovePostInput(Guid Id);

public record AddPostPayload(Post? post, IError[]? errors);

public record RemovePostPayload(Post post);

public record EditPostPayload(Post post);

public class PostMutations
{
    public AddPostPayload AddPost(AddPostInput input, [Service] Storage storage)
    {
        var errors = new List<IError>();

        if(string.IsNullOrEmpty(input.Body))
        {
            errors.Add(new NotEmptyError(nameof(AddPostInput.Body)));
        }

        if (string.IsNullOrEmpty(input.Title))
        {
            errors.Add(new NotEmptyError(nameof(AddPostInput.Title)));
        }

        if (input.Body?.Length >= 1024)
        {
            errors.Add(new MaxLengthError(nameof(AddPostInput.Body), 1024));
        }

        if (input.Title?.Length >= 256)
        {
            errors.Add(new MaxLengthError(nameof(AddPostInput.Title), 256));
        }

        if (errors.Any())
        {
            return new AddPostPayload(null, errors.ToArray());
        }

        var post = new Post() { Id = Guid.NewGuid(), Body = input.Body, Title = input.Title };

        storage.Posts.Add(post);

        return new AddPostPayload(post, null);
    }

    public RemovePostPayload RemovePost(RemovePostInput input, [Service] Storage storage)
    {
        var post = storage.Posts.Single(post => post.Id == input.Id);
        storage.Posts.Remove(post);
        return new RemovePostPayload(post);
    }

    public Post EditPost(EditPostInput input, [Service] Storage storage)
    {
        var post = storage.Posts.FirstOrDefault(post => post.Id == input.Id);

        if(post==null)
        {
            throw new NotFoundException(input.Id);
        }

        post.Body = input.Body;

        return post;
    }
}

