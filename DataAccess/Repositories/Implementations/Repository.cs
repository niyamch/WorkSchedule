using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly WorkScheduleContext context;

        private readonly DbSet<T> set;

        public Repository(WorkScheduleContext context)
        {
            this.context = context;
            this.set = this.context.Set<T>();
        }

        public IEnumerable<T> GetAll(Func<T, bool> filter = null)
        {
            if (filter == null) return this.set;
            else return this.set.Where(filter);
        }

        public void Insert(T entity)
        {
            this.set.Add(entity);
            this.context.SaveChanges();
        }

        public void Update(T entity)
        { 
            this.set.Update(entity);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = this.set.Find(id);
            entity.DeletedOn = DateTime.Now;
            this.set.Update(entity);
            this.context.SaveChanges();
        }

        public T GetById(int id)
            => this.set.Find(id);
    }
}
