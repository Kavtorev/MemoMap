using MemoMap.Domain.SeedWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
        }

        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime Date { get; set; }
        public ICollection<MapLocation> MapLocations { get; set; }

        // one point can include many notes
        public ICollection<Note> Notes { get; set; }
    }
}
