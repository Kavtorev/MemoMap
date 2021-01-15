using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Infrastructure.Repositories
{
    public class MapRepository: Repository<Map>, IMapRepository
    {
        public MapRepository(MemoMapDbContext db) : base(db)
        {

        }
    }
}
