using Quanlykho.Entity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quanlykho.Repositorys
{
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        public UnitRepository(DbContext context) : base(context)
        {
        }

        public async Task AddUnit(Unit entity)
        {
            await base.AddAsync(entity);
        }

        public async Task DeleteUnit(Expression<Func<Unit, bool>> predicate)
        {
            await base.DeleteAsync(predicate);
        }

        public async Task<IQueryable<Unit>> GetAllUnit()
        {
           return await base.GetAllAsync();
        }

        public async Task<Unit> GetById(Expression<Func<Unit, bool>> predicate)
        {
            return await base.GetValueAsync(predicate);
        }

        public async Task UpdateUnit(Unit entity)
        {
            await base.UpdateAsync(entity);
        }
    }
}