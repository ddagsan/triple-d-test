using Services.ExternalServices.Models;
using System.Collections.Generic;

namespace Services.ExternalServices
{
    public interface ICurrencyService : IExternalService
    {
        IEnumerable<Services.Models.Currency> Get();
    }
}