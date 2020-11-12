using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ProjectEntityTypeConfiguration<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public ProjectEntityTypeConfiguration()
        {

        }

        protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
        {
        }

        public void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(m => m.Id);
            this.PostConfigure(builder);
        }
    }
}
