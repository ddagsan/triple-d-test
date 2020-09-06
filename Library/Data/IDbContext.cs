using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        void BeginTransaction(bool handleTransaction = true);
        void CommitTransaction(bool handleTransaction = true);
        void RollbackTransaction(bool handleTransaction = true);
    }
}
