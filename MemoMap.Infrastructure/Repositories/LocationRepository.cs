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
    public class LocationRepository: Repository<Location>, ILocationRepository
    {
        public LocationRepository(MemoMapDbContext db) : base(db)
        {

        }

        public async Task<List<Location>> FindPositionAssociatedWithLocationId (MapLocation l)
        {
            return await _dbContext.Locations
                //.Where(loc => loc.Id == locationId)
                .Where(loc => loc.Id == l.Id)
                .ToListAsync();
        }
    }
}
