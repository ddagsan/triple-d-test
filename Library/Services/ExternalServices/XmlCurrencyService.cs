using RestSharp;
using RestSharp.Serializers;
using Services.Infrastructure.Restsharp.Serializers;
using System;
using ServiceModels = Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.ExternalServices
{
    public class XmlCurrencyService : ICurrencyService
    {
        private const string _sourceUrl = "https://www.tcmb.gov.tr/kurlar/today.xml";
        IRestClient _client;
        public XmlCurrencyService()
        {
            _client = new RestClient(_sourceUrl);
            _client.UseSerializer<CustomXmlSerializer>();
            _client.ThrowOnDeserializationError = true;
        }
        public IEnumerable<ServiceModels.Currency> Get(string sort, string where)
        {
            var request = new RestRequest(Method.GET);
            IRestResponse<Models.MainData> response = _client.Execute<Models.MainData>(request);
            return response.Data.Currencies.Select(m => converToModel(m));
        }

        private ServiceModels.Currency converToModel(Models.Currency currency)
        {
            return new ServiceModels.Currency()
            {
                Code = currency.CurrencyCode,
                BanknoteBuying = currency.BanknoteBuying,
                BanknoteSelling = currency.BanknoteSelling,
                CrossUsdRate = currency.CrossRateUSD,
                ForexBuying = currency.ForexBuying,
                ForexSelling = currency.ForexSelling,
                Name = currency.CurrencyName
            };
        }
    }
}
