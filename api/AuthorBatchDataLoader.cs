using Microsoft.Extensions.Hosting;

namespace api;

public class AuthorBatchDataLoader : BatchDataLoader<Guid, Author>
{
    private readonly Storage _storage;

    public AuthorBatchDataLoader(
        Storage storage,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _storage = storage;
    }

    protected override Task<IReadOnlyDictionary<Guid, Author>> LoadBatchAsync(
        IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        Console.WriteLine($"get authors of posts {string.Join(",", keys.ToArray())}");

        var authors = _storage.Authors.Where(post => keys.Contains(post.Id));

        return Task.FromResult<IReadOnlyDictionary<Guid, Author>>(authors.ToDictionary(x => x.Id));
    }
}
