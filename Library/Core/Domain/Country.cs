using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string Currency { get; set; }
        public virtual ICollection<SpecialDay> SpecialDays { get; set; }
        public virtual ICollection<OffDayOfWeek> OffDaysOfWeek { get; set; }
    }
}
