using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using API.Infrastructure.SupportedFile;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;
using Services.ExternalServices;

namespace API.Controllers
{
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(
            ICurrencyService currencyService
            )
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Services.Models.Currency>), 200)]
        public IActionResult Get(string sort = null, string where = null, SupportedFormatType formatType = SupportedFormatType.XML)
        {
            var result = new CommonResponse();
            
            return Ok(result); ;
        }

        private string getContentType(SupportedFormatType type) 
        {
            switch (type)
            {
                case SupportedFormatType.XML:
                    return "text/xml";
                case SupportedFormatType.CSV:
                    return "text/csv";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
