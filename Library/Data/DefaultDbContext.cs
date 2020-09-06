using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Data
{
    public class DefaultDbContext : DbContext, IDbContext
    {
        private IDbContextTransaction _transaction;
        private static bool migrated = false;

        public DefaultDbContext()
        {
            if (!migrated)
            {
                base.Database.Migrate();
                migrated = true;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration configuration = configurationBuilder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dynamically load all entity and query type configurations
            var typeConfigurations = Assembly.GetExecutingAssembly().GetTypes().Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                    && (type.BaseType.GetGenericTypeDefinition() == typeof(ProjectEntityTypeConfiguration<>)));

            List<IMappingConfiguration> configurations = new List<IMappingConfiguration>();
            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = (IMappingConfiguration)Activator.CreateInstance(typeConfiguration);
                configuration.ApplyConfiguration(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
        public bool TransactionHasCalledMoreThanOne { get; set; }

        public void BeginTransaction(bool handleTransaction)
        {
            if (!handleTransaction) return;
            this.TransactionHasCalledMoreThanOne = this.Database.CurrentTransaction != null;
            _transaction = this.Database.CurrentTransaction ?? this.Database.BeginTransaction();
        }

        public void CommitTransaction(bool handleTransaction = true)
        {
            if (!TransactionHasCalledMoreThanOne) _transaction.Commit();
        }

        public void RollbackTransaction(bool handleTransaction = true)
        {
            if (_transaction != null && _transaction.GetDbTransaction().Connection != null) _transaction.Rollback();
        }
    }
}
