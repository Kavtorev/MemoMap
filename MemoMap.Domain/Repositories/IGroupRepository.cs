using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Domain.Repositories
{
    public interface IGroupRepository: IRepository<Group>
    {
        // add methods which are specific for this entity, otherwise include them to ../SeedWork/IRepository.cs

        Task<List<Group>> FindAllJoinedGroupsAsync(int userId);
        Task<Group> UpsertAsync(Group group);
    }
}
