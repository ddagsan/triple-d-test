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
using System.Linq.Dynamic.Core;

namespace Services.ExternalServices
{

    public class CsvCurrencyService : ICurrencyService
    {
        private const string _sourcePath = "currencies.csv";
        IRestClient _client;
        public CsvCurrencyService()
        {

        }

        public IEnumerable<Services.Models.Currency> Get(string sort, string where)
        {
            using (var reader = new StreamReader(_sourcePath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var retVal = csv.GetRecords<Services.Models.Currency>().AsQueryable();

                    //TODO: sort ortak sınıftan gelebilir xml için de.
                    if (!string.IsNullOrWhiteSpace(where))
                        retVal = retVal.Where(where);
                    if (!string.IsNullOrWhiteSpace(sort))
                        retVal = retVal.OrderBy(sort);

                    return retVal.ToList();
                }
            }
        }
    }
}
