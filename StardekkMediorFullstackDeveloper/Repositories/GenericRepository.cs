using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using StardekkMediorFullstackDeveloper.Interfaces;
using StardekkMediorFullstackDeveloper.Models;

namespace StardekkMediorFullstackDeveloper.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly StardekkDatabaseContext _databaseContext;

        public GenericRepository(StardekkDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(T entity)
        {
            _databaseContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _databaseContext.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _databaseContext.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _databaseContext.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return _databaseContext.Set<T>().Find(Id);
        }

        public void Remove(T entity)
        {
            _databaseContext.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _databaseContext.Set<T>().RemoveRange(entities);
        }
    }
}
