using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Domain.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        Task<List<Location>> FindPositionAssociatedWithLocationId(MapLocation l);
    }
}
