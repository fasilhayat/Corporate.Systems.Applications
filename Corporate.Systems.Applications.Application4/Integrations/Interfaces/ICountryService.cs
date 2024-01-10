using Corporate.Systems.Applications.Application4.Model.Geography;

namespace Corporate.Systems.Applications.Application4.Integrations.Interfaces;

public interface ICountryService
{
    Country? GetCountry(string capitalCityName);
}

