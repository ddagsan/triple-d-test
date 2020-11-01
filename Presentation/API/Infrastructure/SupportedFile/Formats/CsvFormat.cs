using Services.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace API.Infrastructure.SupportedFile.Formats
{
    public class CsvFormat : ISupportedFormat
    {
        private readonly List<Currency> _currencies;
        public CsvFormat(List<Currency> currencies)
        {
            _currencies = currencies;
        }
        public byte[] GetAsByte()
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Currency>));
            using (var ms = new MemoryStream())
            {
                xs.Serialize(ms, _currencies);
                return ms.ToArray();
            }
        }
    }
}
