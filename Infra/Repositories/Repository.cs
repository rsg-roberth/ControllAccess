
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories.Contracts;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DataContext Context;
        protected readonly DbSet<T> DbSet; 
        
        public Repository(DataContext context)
        {
            Context = context;
            DbSet = Context.Set<T>();    
        }
        public virtual void Create(T entity)
        {
            DbSet.Add(entity);
            Context.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            var entity = GetById(id);
            if(entity == null)return; 
            DbSet.Remove(entity);
            Context.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.AsNoTracking();
        }

        public virtual T GetById(Guid id)
        {
            return DbSet.Find(id);            
        }

        public virtual IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
            Context.SaveChanges();

        }
        
        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}