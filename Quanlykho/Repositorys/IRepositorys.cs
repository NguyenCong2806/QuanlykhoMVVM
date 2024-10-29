using Quanlykho.Model;
using Quanlykho.Utilities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quanlykho.Repositorys
{
    public interface IRepositorys<T> where T : class
    {
        Task<ResultData<T>> GetAllAsync<Tkey>(PagedList<T,Tkey> pagedList);
        Task<T> GetValueAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task<int> SaveAsync();
        void Dispose();
        Task DeleteAsync(Expression<Func<T, bool>> predicate);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}