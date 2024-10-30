using Microsoft.EntityFrameworkCore;
using SGuF.Domain.Common.Models;
using SGuF.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SGuF.Application.Common.Interfaces.Base;

namespace SGuF.Infra.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly SGuFDbContext _context;

        public Repository(SGuFDbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(Guid id)
            => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<T>> GetAll()
            => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().Where(predicate).ToListAsync();
        

        public IQueryable<T> AsQueryable(Expression<Func<T, bool>> predicate = null)
            => predicate == null ? _context.Set<T>().AsQueryable() : _context.Set<T>().Where(predicate).AsQueryable();

     

        public async Task<T> AddAsync(T entity)
        {
            try
            {
               // entity.CreatedAt = DateTime.UtcNow;
                //var result = await _context.AddAsync(entity);
                _context.Add(entity);
                await SaveChanges();
            }
            catch (System.Exception)
            {
                throw;
            }

            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await Get(id);
                if (entity == null)
                    return false;

                var result = _context.Set<T>().Remove(entity);
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await Get(entity.Id);
                if (result == null)
                    return null;

                entity.UpdatedAt = DateTime.UtcNow;
                entity.CreatedAt = result.CreatedAt;

                _context.Entry(result).State = EntityState.Detached;
                _context.Set<T>().Update(entity);
            }
            catch (System.Exception)
            {
                throw;
            }

            return entity;
        }

        public async Task<bool> Complete()
           => await _context.SaveChangesAsync() > 0;

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

    }
}
