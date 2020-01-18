using DataAccess.Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll(Func<T, bool> filter = null);
        T GetById(int id);
    }
}
