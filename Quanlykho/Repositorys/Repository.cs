using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Quanlykho.Repositorys
{
    public abstract class Repository<T, TContext> : IRepositorys<T> where T : class where TContext : DbContext
    {
        protected readonly TContext _context;
        private DbSet<T> _table;

        protected Repository(TContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                _table.Add(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IQueryable<T>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetValueAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> SaveAsync()
        {
            await _context.SaveChangesAsync();
            return (int)HttpStatusCode.OK;
        }

        public T UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}