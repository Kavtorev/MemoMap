using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Models
{
    public class Route: Entity
    {
        public Route()
        {
        }
        public string Name { get; set; }
        // one Route can belong to many maps
        public ICollection<MapRoute> MapRoutes { get; set; }

    }
}
