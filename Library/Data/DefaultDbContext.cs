using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
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
