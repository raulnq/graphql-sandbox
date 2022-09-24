namespace api;

public class PostQueriesType : ObjectType<PostQueries>
{
    protected override void Configure(IObjectTypeDescriptor<PostQueries> descriptor)
    {
        descriptor
            .Field(f => f.GetPost(default!, default!))
            .Type<PostType>();

        descriptor
            .Field(f => f.GetPosts(default!))
            .Type<ListType<PostType>>();
    }
}
