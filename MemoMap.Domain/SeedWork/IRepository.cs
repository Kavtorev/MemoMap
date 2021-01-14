using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Domain.SeedWork
{
    public interface IRepository<T> where T:Entity
    {
        Task<T> UpdateAsync(T e);
        Task<T> DeleteAsync(T e);
        // update and insert functionality in a one method, so we don't have to implement Create and Update separately
        T Upsert(T e);

        Task<T> FindByIDAsync(int id);
        // Asychronous methods return Task object.
        Task<T> CreateAsync(T e);   
        Task<List<T>> FindAllAsync();
    }
}
