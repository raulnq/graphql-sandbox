using Microsoft.Extensions.Hosting;

namespace api;

public class AuthorQueries
{
    //public Author? GetAuthor([Parent] Post post, [Service] Storage storage)
    //{
    //    Console.WriteLine($"get author of post {post.Id}");

    //    return storage.Authors.FirstOrDefault(author => author.Id == post.AuthorId);
    //}

    public async Task<Author> GetAuthor([Parent] Post post, AuthorBatchDataLoader loader)
    {
        return await loader.LoadAsync(post.Id);
    }
}
