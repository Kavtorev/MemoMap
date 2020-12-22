using MemoMap.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected MemoMapDbContext _dbContext;
        public Repository(MemoMapDbContext db)
        {
            _dbContext = db;
        }
        public async Task<T> CreateAsync(T e)
        {
            T record = _dbContext.Set<T>().Add(e).Entity;
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<T> DeleteAsync(T e)
        {
            T record = _dbContext.Set<T>().Remove(e).Entity;
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<List<T>> FindAllAsync()
        {
            //vReturns a DbSet<TEntity> instance for access to entities of the given type in the context and the underlying store.
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<T> UpdateAsync(T e)
        {
            T record = _dbContext.Set<T>().Update(e).Entity;
            await _dbContext.SaveChangesAsync();
            return record;
        }

        public T FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public T Upsert(T e)
        {
            throw new NotImplementedException();
        }
    }
}
