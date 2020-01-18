using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Service.Services.Implementations
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> repository;

        public BaseService(IRepository<T> _repository)
        {
            this.repository = _repository;
        }
        public bool Create(T entity)
        {
            try
            {
                repository.Insert(entity);
            } catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int id)
        {
            if (GetById(id).DeletedOn != null)
            {
                try
                {
                    repository.Delete(id);
                } catch (Exception)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public IEnumerable<T> GetAll(Func<T, bool> filter = null)
        {
            return repository.GetAll(filter);
        }

        public IEnumerable<T> GetAllDeleted(Func<T, bool> filter = null)
        {
            IEnumerable<T> list;
            if (filter != null) list = repository.GetAll(filter);
            else list = repository.GetAll();
            List<T> resultList = new List<T>();
            foreach (var item in list)
            {
                if (item.DeletedOn != null) resultList.Add(item);
            }
            return resultList;
        }

        public IEnumerable<T> GetAllExisting(Func<T, bool> filter = null)
        {
            IEnumerable<T> list;
            if (filter != null) list = repository.GetAll(filter);
            else list = repository.GetAll();
            List<T> resultList = new List<T>();
            foreach (var item in list)
            {
                if (item.DeletedOn == null) resultList.Add(item);
            }
            return resultList;
        }

        public T GetById(int id)
        {
            return repository.GetById(id);
        }

        public bool Update(T entity)
        {
            if (repository.GetById(entity.Id).DeletedOn != null)
            {
                try
                {
                    repository.Update(entity);
                } catch (Exception)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
