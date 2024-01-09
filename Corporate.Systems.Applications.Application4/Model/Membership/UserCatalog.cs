namespace Corporate.Systems.Applications.Application4.Model.Membership;

public record UserCatalog
{
    public IEnumerable<User>? Users { get; init; }
}