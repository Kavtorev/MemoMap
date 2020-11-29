using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Models
{
    public class MapLocation
    {

        public int MapId { get; set; }
        public Map Map { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
