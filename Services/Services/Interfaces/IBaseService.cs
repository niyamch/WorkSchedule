using System;
using System.Collections.Generic;
using DataAccess.Entities;

namespace Service.Services.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(Func<T, bool> filter = null);
        IEnumerable<T> GetAllExisting(Func<T, bool> filter = null);
        IEnumerable<T> GetAllDeleted(Func<T, bool> filter = null);
        T GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }
}
