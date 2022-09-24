namespace api;

public class PostType : ObjectType<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
        descriptor
            .Field(f => f.Title)
            .Type<StringType>();

        descriptor
            .Field(f => f.Body)
            .Type<StringType>();

        descriptor
            .Field(f => f.Id)
            .Type<IdType>();
    }
}
