using Corporate.Application.Services.Services.Interfaces;
using Corporate.Systems.Applications.Application4.Infrastructure.Filters;
using Corporate.Systems.Applications.Application4.Integrations;
using Corporate.Systems.Applications.Application4.Model.Geography;
using Microsoft.AspNetCore.Mvc;

namespace Corporate.Systems.Applications.Application4.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;
    private readonly ILogger<CountryService> _logger;
    

    public CountryController(ICountryService countryService, ILogger<CountryService> logger)
    {
        _countryService = countryService;
        _logger = logger;
    }

    [HttpGet(Name = "GeCountry")]
    [TypeFilter(typeof(ControllerFilter))]
    public Country? Get()
    {
        var result = _countryService.GetCountry("Copenhagen");
        return result;
    }
}
