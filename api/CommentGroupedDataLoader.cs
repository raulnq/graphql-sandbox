using Microsoft.Extensions.Hosting;

namespace api;

public class CommentGroupedDataLoader
    : GroupedDataLoader<Guid, Comment>
{
    private readonly Storage _repository;

    public CommentGroupedDataLoader(
        Storage repository,
        IBatchScheduler batchScheduler,
        DataLoaderOptions? options = null)
        : base(batchScheduler, options)
    {
        _repository = repository;
    }


    protected override Task<ILookup<Guid, Comment>> LoadGroupedBatchAsync(
        IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
    {
        Console.WriteLine($"get comments of post {string.Join(",", keys.ToArray())}");

        var persons = _repository.Comments.Where(comment=> keys.Contains(comment.PostId));

        return Task.FromResult<ILookup<Guid,Comment>>(persons.ToLookup(x => x.PostId));
    }
}
