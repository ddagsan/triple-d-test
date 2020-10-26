using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            var items = _currencyService.Get();
            return Ok(items);
        }
    }
}
