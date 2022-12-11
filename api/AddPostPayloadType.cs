namespace api;

public class AddPostPayloadType : ObjectType<AddPostPayload>
{
    protected override void Configure(IObjectTypeDescriptor<AddPostPayload> descriptor)
    {
        descriptor
            .Field(f => f.post)
            .Type<PostType>();

        descriptor
            .Field(f => f.errors)
            .Type<ListType<AddPostPayloadErrorType>>();
    }
}