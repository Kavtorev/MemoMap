using MemoMap.Domain.SeedWork;

namespace MemoMap.Domain.Models
{
    public class MapLocation: Entity
    {

        public int MapId { get; set; }
        public Map Map { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
