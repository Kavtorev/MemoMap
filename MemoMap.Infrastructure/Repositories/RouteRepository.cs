using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.Repositories
{
    public class RouteRepository: Repository<Route>, IRouteRepository
    {
        public RouteRepository(MemoMapDbContext db) : base(db)
        {

        }
    }
}
