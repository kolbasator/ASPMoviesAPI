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
        private CodeFirstContext Context { get; }

        public List<T> GetAll()
        {
            var result = Context.Set<T>().AsQueryable().Select(e => e).ToList();
            return result;
        }

        public List<T> GetMany(Expression<Func<T, bool>> query)
        {
            var result = Context.Set<T>().AsQueryable().Where(query);
            return result.ToList();
        }

        public T Get(Expression<Func<T, bool>> query)
        {
            var result = Context.Set<T>().AsQueryable().FirstOrDefault(query);
            return result;
        }

        public T Add(T model)
        {
            Context.Set<T>().Add(model);
            return model;
        }

        public T Update(T newData, Expression<Func<T, bool>> entityToChange)
        {
            var entityToUpdate = Context.Set<T>().FirstOrDefault(entityToChange);
            
            if (entityToUpdate != null)
            {
                entityToUpdate = newData;
            }
            
            return entityToUpdate;
        }

        public void Delete(T model)
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