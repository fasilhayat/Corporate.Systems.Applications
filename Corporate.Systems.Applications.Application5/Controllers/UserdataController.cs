using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;

namespace Corporate.Systems.Applications.Application5.Controllers;

public class UserdataController : GraphController
{
    [QueryRoot("users")]
    public IEnumerable<User> RetrieveUsers()
    {
        return new List<User>
        {
            new()
            {
                Id = 1,
                Name = "Noble Fulton",
                Guid = "94744e79-6da7-426b-ab70-110b2719114b",
                Age = 25,
                Gender = "Male"
            },
            new()
            {
                Id = 2,
                Name = "Renee Morrow",
                Guid = "386a9a65-6dff-4bf9-b45a-7d7e07f14c77",
                Age = 36,
                Gender = "Male"
            },
            new()
            {
                Id = 3,
                Name = "Juliet Lynch",
                Guid = "1e00db63-144c-4661-aad8-6e7a55291b9f",
                Age = 18,
                Gender = "Female"
            }
        };
    }

    [QueryRoot("user")]
    public User? RetrieveUser(int id)
    {
        return RetrieveUsers().SingleOrDefault(x => x.Id == id);
    }

    [QueryRoot("usersearch")]
    public User? RetrieveUser(string name)
    {
        return RetrieveUsers().SingleOrDefault(x => x.Name != null && x.Name.Contains(name));
    }
}

public class User
{
    public int Id { get; init; }

    public string? Guid { get; init; }

    public string? Name { get; init; }

    public string? Gender { get; init; }

    public int Age { get; init; }
}