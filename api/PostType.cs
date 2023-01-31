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

        descriptor
            .Field(f => f.Comments)
            .ResolveWith<CommentsQueries>(r => r.GetComments(default!, default!))
            .Type<ListType<CommentType>>();

        descriptor
            .Field(f => f.Author)
            .ResolveWith<AuthorQueries>(r => r.GetAuthor(default!, default!))
            .Type<AuthorType>();

        descriptor
            .Field(f => f.AuthorId)
            .Ignore();
    }
}
