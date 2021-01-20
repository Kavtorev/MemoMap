using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Infrastructure.Repositories
{
    public class GroupUserRepository : Repository<GroupUser>, IGroupUserRepository
    {
        public GroupUserRepository(MemoMapDbContext db) : base(db)
        {
        }

        public async Task<List<GroupUser>> FindAllJoinedGroupsAsync(int userId)
        {
            return await _dbContext.GroupUsers
                .Include(g2u => g2u.Group)
                .Where(g2u => g2u.UserId == userId)
                .ToListAsync();
        }

        public async Task<GroupUser> FindByUserGroupId(int userId, int groupId)
        {
            return await _dbContext.GroupUsers
                .Where(e => e.UserId == userId && e.GroupId == groupId)
                .SingleOrDefaultAsync();
        }
    }
}
