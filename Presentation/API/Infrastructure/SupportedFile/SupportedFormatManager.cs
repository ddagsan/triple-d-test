using API.Infrastructure.SupportedFile.Formats;
using Services.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infrastructure.SupportedFile
{
    public class SupportedFormatManager
    {
        ISupportedFormat format;
        public SupportedFormatManager(List<Services.Models.Currency> currencies, SupportedFormatType type)
        {
            switch (type)
            {
                case SupportedFormatType.XML:
                    format = new XmlFormat(currencies);
                    break;
                case SupportedFormatType.CSV:
                    format = new CsvFormat(currencies);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public byte[] GetResultAsBytes() 
        {
            return format.GetAsByte();
        }
    }
}
