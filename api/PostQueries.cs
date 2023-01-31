using GreenDonut;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace api;

public class PostQueries
{
    public List<Post> GetPosts([Service] Storage storage)
    {
        Console.WriteLine($"get all posts");

        return storage.Posts;
    }

    public Post? GetPost(Guid id, [Service] Storage storage)
    {
        Console.WriteLine($"get post {id}");

        return storage.Posts.FirstOrDefault(post => post.Id == id);
    }
}