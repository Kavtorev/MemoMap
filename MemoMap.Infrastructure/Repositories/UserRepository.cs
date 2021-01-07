using MemoMap.Domain;
using MemoMap.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Infrastructure.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(MemoMapDbContext db) : base(db)
        {

        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(m => m.Email == email);
        }

        public async Task<User> FindByUsernameAndPasswordAsync(string username, string password)
        {
            // verify password against hash stored in the db
            return await _dbContext.Users.SingleOrDefaultAsync(m => m.Username == username &&
                m.Password == password);

        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(m => m.Username == username);
        }


    }
}
