using Corporate.Systems.Applications.Application4.Model.Membership;

namespace Corporate.Application.Services.Services.Interfaces;

public interface IUserService   
{
    IEnumerable<User>? GetUsers();

    void AddUser(User user);
}
