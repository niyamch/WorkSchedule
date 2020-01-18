using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities; 

namespace Service.Interfaces
{
    public interface IBaseService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll(Func<T, bool> filter = null);
        T GetById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
    }

}
