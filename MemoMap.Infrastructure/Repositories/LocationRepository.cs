using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.Repositories
{
    public class LocationRepository: Repository<Location>, ILocationRepository
    {
        public LocationRepository(MemoMapDbContext db) : base(db)
        {

        }
    }
}
