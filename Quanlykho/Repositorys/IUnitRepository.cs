using Quanlykho.Entity;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quanlykho.Repositorys
{
    public interface IUnitRepository : IRepositorys<Unit>
    {
        Task<IQueryable<Unit>> GetAllUnit();
        Task<Unit> GetById(Expression<Func<Unit, bool>> predicate);
        Task AddUnit(Unit entity);
        Task DeleteUnit(Expression<Func<Unit, bool>> predicate);
        Task UpdateUnit(Unit entity);
    }
}