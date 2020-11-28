using MemoMap.Domain.SeedWork;
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
        public Task<T> CreateAsync(T e)
        {
            throw new NotImplementedException();
        }

        public T Delete(T e)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> FindAll()
        {
            throw new NotImplementedException();
        }

        public T FindByID(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(T e)
        {
            throw new NotImplementedException();
        }

        public T Upsert(T e)
        {
            throw new NotImplementedException();
        }
    }
}
