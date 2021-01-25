
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

        public async Task<List<User>> FindAllGroupModerators(int groupId)
        {
            var res = await _dbContext.Users
                .Where(user => user.GroupUsers
                .Any(u2g => u2g.GroupId == groupId && u2g.IsModerator))
                .ToListAsync();
            return res;
        }

        public async Task<List<User>> FindAllGroupNormalUsers(int groupId)
        {
            var res = await _dbContext.Users
                .Where(user => user.GroupUsers
                .Any(u2g => u2g.GroupId == groupId && !u2g.IsAdmin && !u2g.IsModerator))
                .ToListAsync();
            return res;
        }

        public User FindGroupAdmin(int groupId)
        {
            var res =  _dbContext.Users
                .Where(user => user.GroupUsers
                .Any(u2g => u2g.GroupId == groupId && u2g.IsAdmin))
                .SingleOrDefault();

            return res;
        }

        public async Task<Group> UpsertAsync(Group group)
        {
            if (group.Id == 0)
            {
                return await this.CreateAsync(group);
            }
            await this.UpdateAsync(group);

            return null;
        }
    }
}
    