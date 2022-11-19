using api;

var builder = WebApplication.CreateBuilder(args);

var posts = Enumerable.Range(0, 20).Select(index => new Post() { Body = $"Body {index}", Id = Guid.NewGuid(), Title = $"Title {index}" });

builder.Services.AddSingleton(new Storage() { Posts = new List<Post>(posts) });

builder.Services
    .AddGraphQLServer()
    .AddQueryType<PostQueriesType>()
    .AddMutationType<PostMutationsType>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

app.MapGraphQL();

app.Run();
