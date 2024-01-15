using Corporate.Systems.Applications.Application5.Model;
using Corporate.Systems.Applications.Application5.Redis.Adapter;
using Corporate.Systems.Applications.Common;
using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;

namespace Corporate.Systems.Applications.Application5.Controllers;

public class UserdataController : GraphController
{
    private readonly IDbContext _dbContext;

    public UserdataController(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [QueryRoot("user")]
    public User? RetrieveUser(string id)
    {
        IDataKey datakey = new DataKey(id);
        var user = _dbContext.GetData<User>(datakey);
        return user ?? new User();
    }
}
