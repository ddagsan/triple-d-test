using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services.CalculationServices;
using Web.Models;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICalculationService _calculationService;

        public IndexModel(
            ILogger<IndexModel> logger,
            ICalculationService calculationService
            )
        {
            _logger = logger;
            _calculationService = calculationService;
        }

        public void OnGet()
        {

        }

        public void OnPost()
        {
            DateTime start = DateTime.Parse(Request.Form["startDate"].ToString());
            DateTime end = DateTime.Parse(Request.Form["endDate"].ToString());
            int countryId = int.Parse(Request.Form["countryId"].ToString());
            var result = _calculationService.Calculate(start, end, countryId);

            ViewData["result"] = result;
        }
    }
}
