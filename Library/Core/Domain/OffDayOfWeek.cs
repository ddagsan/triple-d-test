using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    /// <summary>
    /// it represents national and religious holidays for specific country
    /// </summary>
    public class OffDayOfWeek : BaseEntity
    {
        public virtual Country Country { get; set; }
        public int CountryId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }
}
