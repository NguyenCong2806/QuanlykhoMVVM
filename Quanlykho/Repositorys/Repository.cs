using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
            finally
            {
                Dispose();
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new System.NotImplementedException();
        }
        public async Task DeleteAsync(T entity)
        {
            try
            {
                _table.Remove(entity);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var data = await GetValueAsync(predicate);
                _table.Remove(data);
                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            try
            {
                var data = await _table.ToListAsync();
                return data.AsQueryable<T>();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public async Task<T> GetValueAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _table.FirstOrDefaultAsync<T>(predicate);
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
            finally
            {
                Dispose();
            }
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