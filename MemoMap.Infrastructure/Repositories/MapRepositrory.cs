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

        public async Task<Map> UpsertAsync(Map map)
        {
            // if doesn't exists - create
            if (map.Id == 0) { return await CreateAsync(map); }
            // otherwise the record will be updated
            await this.UpdateAsync(map);

            return null;
        }
    }
}
