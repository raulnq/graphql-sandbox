using HotChocolate.Data.Filters;
using HotChocolate.Types.Pagination;
using Microsoft.Extensions.Options;

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
            .Type<ListType<PostType>>()
            .UsePaging(options: new PagingOptions()
            {
                MaxPageSize = 10,
                DefaultPageSize = 5,
                IncludeTotalCount = true,
            })
            .UseFiltering<PostFilterType>()
            .UseSorting<PostSortType>();
    }
}