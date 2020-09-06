using Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class SpecialDayMap : ProjectEntityTypeConfiguration<SpecialDay>
    {
        public override void Configure(EntityTypeBuilder<SpecialDay> builder)
        {
            base.Configure(builder);
        }
    }
}
