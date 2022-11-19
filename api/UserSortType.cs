using HotChocolate.Data.Sorting;

namespace api;

public class PostSortType : SortInputType<Post>
{
    protected override void Configure(ISortInputTypeDescriptor<Post> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(f => f.Title).Name("topic");
    }
}