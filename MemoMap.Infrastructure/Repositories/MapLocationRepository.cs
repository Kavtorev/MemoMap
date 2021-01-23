using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Infrastructure.Repositories
{
    public class MapLocationRepository : Repository<MapLocation>, IMapLocationRepository
    {
        public MapLocationRepository(MemoMapDbContext db) : base(db)
        {

        }
    }
}
