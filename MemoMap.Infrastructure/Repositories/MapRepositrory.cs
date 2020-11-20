using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.Repositories
{
    public class MapRepository: Repository<Map>, IMapRepository
    {
        public MapRepository(MemoMapDbContext db) : base(db)
        {

        }
    }
}
