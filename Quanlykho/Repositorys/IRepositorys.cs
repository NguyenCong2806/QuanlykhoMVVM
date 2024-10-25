using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quanlykho.Repositorys
{
    public interface IRepositorys<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetValueAsync(int id);
        Task AddAsync(T entity);
        void AddRange(IEnumerable<T> entities);
        Task<int> SaveAsync();
        Task DeleteAsync(int id);
        void DeleteAsync(T entity);
        T UpdateAsync(T entity);
    }
}