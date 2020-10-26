using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models.Web
{
    public class Sorting
    {

        //[BindProperty(Name = "NameAsc", SupportsGet = true)]
        public bool NameAsc { get; set; } = true;
        //[BindProperty(Name = "ForexBuyingAsc", SupportsGet = true)]
        public bool ForexBuyingAsc { get; set; } = true;
        //[BindProperty(Name = "ForexSellingAsc", SupportsGet = true)]
        public bool ForexSellingAsc { get; set; } = true;
    }
}
