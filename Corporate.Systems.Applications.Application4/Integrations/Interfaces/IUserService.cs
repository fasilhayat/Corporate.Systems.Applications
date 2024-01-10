using Corporate.Systems.Applications.Application4.Model.Membership;

namespace Corporate.Systems.Applications.Application4.Integrations.Interfaces;

public interface IUserService   
{
    IEnumerable<User>? GetUsers();

    void AddUser(User user);
}
