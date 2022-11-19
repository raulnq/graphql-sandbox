using HotChocolate.Data.Filters;

namespace api;

public class PostFilterType : FilterInputType<Post>
{
    protected override void Configure(
        IFilterInputTypeDescriptor<Post> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(f => f.Title).Name("topic").Type<TitleOperationFilterInput>();
    }
}
public class TitleOperationFilterInput : StringOperationFilterInputType
{
    protected override void Configure(IFilterInputTypeDescriptor descriptor)
    {
        descriptor.Operation(DefaultFilterOperations.Contains).Type<StringType>();
        descriptor.AllowOr(false);
    }
}
