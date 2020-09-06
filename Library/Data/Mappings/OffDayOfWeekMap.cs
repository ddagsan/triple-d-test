using Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class OffDayOfWeekMap : ProjectEntityTypeConfiguration<OffDayOfWeek>
    {
        public override void Configure(EntityTypeBuilder<OffDayOfWeek> builder)
        {
            base.Configure(builder);
        }
    }
}
