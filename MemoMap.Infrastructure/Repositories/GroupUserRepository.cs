using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Infrastructure.Repositories
{
    public class GroupUserRepository : IGroupUserRepository<GroupUser>
    {
        protected MemoMapDbContext _dbContext;
        public GroupUserRepository(MemoMapDbContext db)
        {
            _dbContext = db;
        }

        public async Task<GroupUser> CreateAsync(GroupUser e)
        {
            GroupUser res = _dbContext.Set<GroupUser>().Add(e).Entity;
            await _dbContext.SaveChangesAsync();
            return res;
        }
    }
}
