using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RESTAPI.Repositories.Interfaces
{
    public interface IRepository<T>
    { 
        List<T> GetAll();
        T Get(Expression<Func<T, bool>> query);
        List<T> GetMany(Expression<Func<T, bool>> query);
        T Add(T model);
        T Update(T newData, Expression<Func<T, bool>> entityToChange); 
        void Delete(T model);
        int SaveChanges();
    }
}
