using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using RESTAPI.Data;
using RESTAPI.Repositories.Interfaces;

namespace RESTAPI.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public CodeFirstContext Context { get; set; }

        public virtual List<T> GetAll()
        {
            var result = Context.Set<T>().AsQueryable().Select(e => e).ToList();
            return result;
        }

        public virtual List<T> GetMany(Expression<Func<T, bool>> query)
        {
            var result = Context.Set<T>().AsQueryable().Where(query);
            return result.ToList();
        }

        public virtual T Get(Expression<Func<T, bool>> query)
        {
            var result = Context.Set<T>().AsQueryable().FirstOrDefault(query);
            return result;
        }

        public virtual T Add(T model)
        {
            Context.Set<T>().Add(model);
            return model;
        }

        public virtual T Update(T newData, Expression<Func<T, bool>> entityToChange)
        {
            var entityToUpdate = Context.Set<T>().FirstOrDefault(entityToChange);
            
            if (entityToUpdate != null)
            {
                entityToUpdate = newData;
            }
            
            return entityToUpdate;
        }

        public virtual void Delete(T model)
        {
            Context.Set<T>().Remove(model);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Repository(CodeFirstContext context)
        {
            Context = context;
        }
    }
}