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
            Maps = new List<Map>();
        }

        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Map> Maps { get; set; }
    }
}
