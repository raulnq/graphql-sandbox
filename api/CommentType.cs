namespace api;

public class CommentType : ObjectType<Comment>
{
    protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
    {
        descriptor
            .Field(f => f.Description)
            .Type<StringType>();

        descriptor
            .Field(f => f.PostId)
            .Type<IdType>();

        descriptor
            .Field(f => f.Id)
            .Type<IdType>();
    }
}

