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
    public class MapLocationRepository : Repository<MapLocation>, IMapLocationRepository
    {
        public MapLocationRepository(MemoMapDbContext db) : base(db)
        {

        }

        public async Task<List<MapLocation>> FindAllRelatedLocationsAsync(int mapId)
        {
            return await _dbContext.MapLocations
                .Include(m2l => m2l.Location)
                .Where(m2l => m2l.MapId == mapId)
                .ToListAsync();
        }
    }
}
