namespace api;

public class PostMutationsType : ObjectType<PostMutations>
{
    protected override void Configure(
        IObjectTypeDescriptor<PostMutations> descriptor)
    {
        descriptor.Field(f => f.AddPost(default!, default!));
        descriptor.Field(f => f.RemovePost(default!, default!));
        descriptor.Field(f => f.EditPost(default!, default!));
    }
}
