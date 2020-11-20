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
            Routes = new List<Route>();
            Points = new List<Point>();
        }
        public string  MapName { get; set; }
        public int GroupId { get; set; }
        // one map can belong only to one group
        public Group Group { get; set; }
        public ICollection<Point> Points { get; set; }
        public ICollection<User> Users { get; set; }
        // one map can include many routes
        public ICollection<Route> Routes { get; set; }
    }
}
