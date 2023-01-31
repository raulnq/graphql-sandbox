namespace api;

public class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor
            .Field(f => f.Name)
            .Type<StringType>();

        descriptor
            .Field(f => f.Id)
            .Type<IdType>();
    }
}

