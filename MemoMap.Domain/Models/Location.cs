using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace MemoMap.Domain.Models
{
    public class Location: Entity
    {
        /*
        point_id int
        longitude string
        latitude string 
        date   Date
          */

        public Location()
        {
            Date = DateTime.Now;
        }

        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime Date { get; set; }
        public ICollection<MapLocation> MapLocations { get; set; }

        // one point can include one note
        public Note Note { get; set; }
    }
}
