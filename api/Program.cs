using api;

var builder = WebApplication.CreateBuilder(args);

var author = new Author() { Id= Guid.NewGuid(), Name="Name" };

var posts = Enumerable.Range(0, 20).Select(index => new Post() {
    Body = $"Body {index}", Id = Guid.NewGuid(), Title = $"Title {index}", AuthorId = author.Id
}).ToList();

var comments = new List<Comment>();

foreach (var post in posts)
{
    var list = Enumerable.Range(0, 5).Select(index => new Comment()
    {
        PostId = post.Id,
        Id = Guid.NewGuid(),
        Description = $"Description {post.Id} {index}"
    }).ToList();

    comments.AddRange(list);
}

builder.Services.AddSingleton(new Storage() { Posts = new List<Post>(posts), Comments = comments, Authors = new List<Author>() { author } });

builder.Services
    .AddGraphQLServer()
    .AddMutationConventions(applyToAllMutations: false)
    .AddQueryType<PostQueriesType>()
    .AddMutationType<PostMutationsType>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.MapGraphQL();

app.Run();
