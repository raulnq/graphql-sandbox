using api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(new Storage());

builder.Services
    .AddGraphQLServer()
    .AddQueryType<PostQueriesType>()
    .AddMutationType<PostMutationsType>()
    ;

var app = builder.Build();

app.MapGraphQL();

app.Run();
