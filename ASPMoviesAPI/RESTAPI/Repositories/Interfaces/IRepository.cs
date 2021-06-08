using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RESTAPI.Models;

namespace RESTAPI.Repositories.Interfaces
{
    public interface IRepository<T>
    { 
        List<T> GetAll();
        T Get(Expression<Func<T, bool>> query);
        List<T> GetMany(Expression<Func<T, bool>> query);
        T Post(T model);
        T Put(T newData, Expression<Func<T, bool>> entityToChange); 
        void Delete(T model);
    }
}
