using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Models
{
    public class Currency
    {
        public string Name { get; set; }
        public int Unit { get; set; }
        public string Code { get; set; }
        public double? ForexBuying { get; set; }
        public double? ForexSelling { get; set; }
        public double? BanknoteBuying { get; set; }
        public double? BanknoteSelling { get; set; }
        public double? CrossUsdRate { get; set; }
    }
}
