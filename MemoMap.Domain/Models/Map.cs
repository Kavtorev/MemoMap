using MemoMap.Domain.SeedWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Models
{
    public class Map: Entity
    {
        public Map()
        {
        }
        public string  MapName { get; set; }
        public int GroupId { get; set; }
        // one map can belong only to one group
        public Group Group { get; set; }
        public ICollection<MapLocation> MapLocations { get; set; }
        public ICollection<UserMap> UserMaps { get; set; }
        // one map can include many routes
        public ICollection<MapRoute> MapRoutes { get; set; }
    }
}
