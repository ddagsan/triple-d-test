using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CalculateRequestModel
    {
        public string DateCheckedOut { get; set; }
        public string DateReturned { get; set; }
        public int CountryId { get; set; }
    }
}
