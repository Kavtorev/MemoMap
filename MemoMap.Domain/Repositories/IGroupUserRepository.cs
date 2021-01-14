using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Domain.Repositories
{
    public interface IGroupUserRepository<T>
    {
        Task<T> CreateAsync(T e);
    }
}
