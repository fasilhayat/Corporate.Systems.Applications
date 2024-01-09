using Corporate.Systems.Applications.Application4.Model.Geography;

namespace Corporate.Application.Services.Services.Interfaces;

public interface ICountryService
{
    Country? GetCountry(string capitalCityName);
}

