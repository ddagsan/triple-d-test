using Services.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ServiceStack.Text;

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
            using (var ms = new MemoryStream())
            {
                CsvSerializer.SerializeToStream(_currencies, ms);
                return ms.ToArray();
            }
        }
    }
}
