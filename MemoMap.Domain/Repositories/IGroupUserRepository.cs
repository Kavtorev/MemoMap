using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Domain.Repositories
{
    public interface IGroupUserRepository : IRepository<GroupUser>
    {
        Task<GroupUser> FindByUserGroupId(int userId, int groupId);
        Task<List<GroupUser>> FindAllJoinedGroupsAsync(int userId);
    }
}
