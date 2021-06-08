using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;  
using RESTAPI.Models;
using RESTAPI.Repositories.Interfaces;

namespace RESTAPI.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private CodeFirstContext _context { get; set; }

        public List<T> GetAll()
        {
            var result = _context.Set<T>().AsQueryable().Select(e=>e).ToList();
            return result;
        }

        public List<T> GetMany(Expression<Func<T,bool>> query)
        {
            var result = _context.Set<T>().AsQueryable().Where(query);
            return result.ToList();
        } 
        public T Get(Expression<Func<T, bool>> query)
        {
            var result = _context.Set<T>().AsQueryable().FirstOrDefault(query);
            return result;
        }
        public T Post(T model)
        {
            _context.Set<T>().Add(model);
            _context.SaveChanges();
            return model;
        }

        public T Put(T newData, Expression<Func<T, bool>> entityToChange)
        {
            var entityToUpdate = _context.Set<T>().FirstOrDefault(entityToChange);
            if (entityToUpdate != null)
            {
                entityToUpdate = newData;
            }
            _context.Update(entityToChange);
            _context.SaveChanges();
            return newData;

        }
        public void Delete(T model)
        {
            _context.Set<T>().Remove(model);
            _context.SaveChanges();
        } 
        public Repository(CodeFirstContext context)
        {
            _context = context;
        }
    }
}
