using Quanlykho.Entity;
using Quanlykho.Model;
using Quanlykho.Utilities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quanlykho.Repositorys
{
    public interface IUnitRepository : IRepositorys<Unit>
    {
        Task<ResultData<Unit>> GetAllUnit(PagedList<Unit,int> pagedList);
        Task<Unit> GetById(Expression<Func<Unit, bool>> predicate);
        Task AddUnit(Unit entity);
        Task DeleteUnit(Expression<Func<Unit, bool>> predicate);
        Task UpdateUnit(Unit entity);
    }
}