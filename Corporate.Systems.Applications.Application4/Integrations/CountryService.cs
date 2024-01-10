using Corporate.Systems.Applications.Application4.Infrastructure;
using Corporate.Systems.Applications.Application4.Integrations.Interfaces;
using Corporate.Systems.Applications.Application4.Model.Geography;

namespace Corporate.Systems.Applications.Application4.Integrations;

public class CountryService : ICountryService
{
    private readonly IServiceFactory<CountryService> _serviceFactory;
    private readonly ILogger<CountryService> _logger;

    public CountryService(IServiceFactory<CountryService> serviceFactory, ILogger<CountryService> logger)
    {
        _serviceFactory = serviceFactory;
        _logger = logger;
    }

    public Country GetCountry(string cityName)
    {
        var parameters = $"/capital/{cityName}";
        var country = _serviceFactory.Execute<List<Country>>(parameters).Result;

        return country!.First();
    }
}
