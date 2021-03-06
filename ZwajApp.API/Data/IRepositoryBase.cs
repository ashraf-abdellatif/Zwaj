using System;
using System.Linq;
using System.Linq.Expressions;

namespace ZwajApp.API.Data
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        T GetByID(object id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}