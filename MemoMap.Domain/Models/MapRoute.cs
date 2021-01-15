using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Models
{
    public class MapRoute: Entity
    {
        public int MapId { get; set; }
        public Map Map { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
    }
}
