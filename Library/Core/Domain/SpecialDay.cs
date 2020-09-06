using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    /// <summary>
    /// it represents national and religious holidays for specific country
    /// </summary>
    public class SpecialDay : BaseEntity
    {
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        public DateTime SpecialDate { get; set; }
    }
}
