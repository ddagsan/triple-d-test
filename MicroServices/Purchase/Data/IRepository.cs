using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void InsertWithoutCommit(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateWithoutCommit(TEntity entity);
        void Delete(TEntity entity);
        void DeleteWithoutCommit(TEntity entity);
        void Commit();
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
    }
}
