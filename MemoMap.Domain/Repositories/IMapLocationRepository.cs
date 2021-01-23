using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Repositories
{
    public interface IMapLocationRepository: IRepository<MapLocation>
    {
        // add methods which are specific for this entity, otherwise include them to ../SeedWork/IRepository.cs
        // initializing new list of points for new map

    }
}
