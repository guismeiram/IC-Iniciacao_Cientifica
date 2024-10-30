using SGuF.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SGuF.Application.Common.Interfaces.Base
{
    public interface IRepository<T> where T : BaseEntity
    {
        /*Task<T> Get(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
        IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate = null);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        
        */
        Task<bool> Complete();
        Task<int> SaveChanges();
        Task<T> Get(Guid id);

        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

        IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate = null);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(Guid id);

    }
}
