using Corporate.Systems.Applications.Application4.Infrastructure.Filters;
using Corporate.Systems.Applications.Application4.Integrations;
using Corporate.Systems.Applications.Application4.Integrations.Interfaces;
using Corporate.Systems.Applications.Application4.Model.Membership;
using Microsoft.AspNetCore.Mvc;

namespace Corporate.Systems.Applications.Application4.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserService> _logger;

    public UserController(IUserService userService, ILogger<UserService> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [HttpGet(Name = "GetUsers")]
    [TypeFilter(typeof(ControllerFilter))]
    [TypeFilter(typeof(UserFilter))]
    public UserCatalog Get()
    {
        //var result = _userService.GetUsers();
        //{
        //    Users = result
        //};
        //return new UserCatalog

        return new UserCatalog
        {
            Users = new List<User>
            {
                new()
                {
                    Id = 1,
                    Uid = Guid.NewGuid().ToString(),
                    Email = "my@email.com",
                    Firstname = "Fasil Malik",
                    Lastname = "Hayat",
                    Password = "p@ssword!",
                    Username = "Usern@me"
                }
            }
        };
    }

    [HttpPost(Name = "AddUser")]
    [TypeFilter(typeof(ControllerFilter))]
    [TypeFilter(typeof(UserFilter))]
    public void Add(User user)
    {
        _userService.AddUser(user);
    }
}
