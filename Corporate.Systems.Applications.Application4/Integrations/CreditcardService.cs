using Corporate.Systems.Applications.Application4.Infrastructure;
using Corporate.Systems.Applications.Application4.Integrations.Interfaces;
using Corporate.Systems.Applications.Application4.Model.Finance;

namespace Corporate.Systems.Applications.Application4.Integrations;

public class CreditcardService : ICreditcardService
{
    private readonly IServiceFactory<CreditcardService> _serviceFactory;
    private readonly ILogger<CreditcardService> _logger;

    public CreditcardService(IServiceFactory<CreditcardService> serviceFactory, ILogger<CreditcardService> logger)
    {
        _serviceFactory = serviceFactory;
        _logger = logger;
    }

    public Creditcard? GetCreditcard()
    {
        var parameters = "/credit_cards";
        return _serviceFactory.Execute<Creditcard>(parameters).Result;
    }
}