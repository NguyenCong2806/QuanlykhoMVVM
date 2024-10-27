using Quanlykho.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;

namespace Quanlykho.Repositorys
{
    public abstract class Repository<T> : IRepositorys<T> where T : class
    {
        protected readonly DbContext _context;
        private DbSet<T> _table;

        protected Repository(DbContext context)
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
        }

        public async Task<int> SaveAsync()
        {
            await _context.SaveChangesAsync();
        
            return (int)HttpStatusCode.OK;
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;

                await SaveAsync();
            }
            catch (Exception ex)
            {
                throw new System.NotImplementedException(ex.Message);
            }
        }

        //public async Task UpdateAsync(T entity, Expression<Func<T, object>>[] properties)
        //{
        //    try
        //    {
        //        var dbEntry = _context.Entry(entity);
        //        foreach (var includeProperty in properties)
        //        {
        //            dbEntry.Property(includeProperty).IsModified = true;
        //        }
        //       await SaveAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new System.NotImplementedException(ex.Message);
        //    }
        //}
    }
}