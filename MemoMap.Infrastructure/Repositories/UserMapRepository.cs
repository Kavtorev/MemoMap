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
    public class UserMapRepository : Repository<UserMap>, IUserMapRepository
    {
        public UserMapRepository(MemoMapDbContext db) : base(db)
        {

        }

        public async Task<List<UserMap>> FindAllJoinedMapsAsync(int userId)
        {
            return await _dbContext.UserMaps
                .Include(u2m => u2m.Map)
                .Where(u2m => u2m.UserId == userId && u2m.Map.GroupId == null)
                .ToListAsync();
        }

        public async Task<UserMap> FindByUserMapId(int userId, int mapId)
        {
            return await _dbContext.UserMaps
                .Where(e => e.UserId == userId && e.MapId == mapId)
                .SingleOrDefaultAsync();
        }
    }
}
