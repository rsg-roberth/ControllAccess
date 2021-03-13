using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Repositories.Contracts
{
    public interface IRepository<T>: IDisposable where T: Entity
    {
        void Create(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Delete(Guid id);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicate);

    }
}