using Corporate.Systems.Applications.Application4.Infrastructure.Filters;
using Corporate.Systems.Applications.Application4.Integrations;
using Corporate.Systems.Applications.Application4.Integrations.Interfaces;
using Corporate.Systems.Applications.Application4.Model.Finance;
using Microsoft.AspNetCore.Mvc;

namespace Corporate.Systems.Applications.Application4.Controllers;

[ApiController]
[Route("[controller]")]
public class CreditcardController : ControllerBase
{
    private readonly ICreditcardService _creditcardService;
    private readonly ILogger<CreditcardService> _logger;
    
    public CreditcardController(ICreditcardService creditcardService, ILogger<CreditcardService> logger)
    {
        _creditcardService = creditcardService;
        _logger = logger;
    }

    [HttpGet(Name = "GetCreditcard")]
    [TypeFilter(typeof(ControllerFilter))]
    public Creditcard Get()
    {
        //var result = _creditcardService.GetCreditcard();
        var result = new Creditcard
        {
            Id = 1,
            Credit_Card_ExpiryDate = DateTime.Today,
            Credit_Card_Number = "01023034585-2024520",
            Credit_Card_Type = "MasterCard",
            Uid = Guid.NewGuid().ToString()
        };
        return result!;
    }
}
