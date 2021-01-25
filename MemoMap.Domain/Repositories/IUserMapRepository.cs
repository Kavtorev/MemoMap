using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Domain.Repositories
{
    public interface IUserMapRepository : IRepository<UserMap>
    {
        Task<UserMap> FindByUserMapId(int userId, int mapId);
        Task<List<UserMap>> FindAllJoinedMapsAsync(int userId);
    }
}
