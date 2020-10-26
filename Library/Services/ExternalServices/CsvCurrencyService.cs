using CsvHelper;
using RestSharp;
using RestSharp.Serializers;
using Services.ExternalServices.Models;
using Services.Infrastructure.Restsharp.Serializers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Services.ExternalServices
{
    public class CsvCurrencyService : ICurrencyService
    {
        private const string _sourcePath = "currencies.csv";
        IRestClient _client;
        public CsvCurrencyService()
        {
            
        }

        public IEnumerable<Services.Models.Currency> Get()
        {
            using (var reader = new StreamReader(_sourcePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return csv.GetRecords<Services.Models.Currency>().ToList();
                }
            }
        }
    }
}
