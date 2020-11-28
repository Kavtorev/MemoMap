using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace MemoMap.Domain.Repositories
{
    public interface ILocationRepository : IRepository<Location>
    {
        // add methods which are specific for this entity, otherwise include them to ../SeedWork/IRepository.cs
    }
}
