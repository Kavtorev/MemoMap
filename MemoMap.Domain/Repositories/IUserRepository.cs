using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        // add methods which are specific for this entity, otherwise include them to ../SeedWork/IRepository.cs
        Task<User> FindByUsernameAndPasswordAsync(string username, string password);
        Task<User> FindByUsernameAsync(string username);
        Task<User> FindByEmailAsync(string email);
    }
}
