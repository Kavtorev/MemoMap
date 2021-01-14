
using MemoMap.Domain;
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
    public class GroupRepository: Repository<Group>, IGroupRepository
    {
        public GroupRepository(MemoMapDbContext db):base(db)
        {
            
        }

        public async Task<List<Group>> FindAllJoinedGroupsAsync(int userId)
        {
            var res = await _dbContext.Groups
                .Where(group => group.GroupUsers
                .Any(g2u => g2u.UserId == userId))
                .ToListAsync();

            return res;
        }

    }
}
