using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Repositories
{
    public interface IRouteRepository : IRepository<Route>
    {
        // add methods which are specific for this entity, otherwise include them to ../SeedWork/IRepository.cs
    }
}
