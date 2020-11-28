using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace MemoMap.Domain.Models
{
    public class Note : Entity
    {
        /*
         note_id int
         title string 
         description string
         image byte
         location_id FK
        */
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        
        // one note can belong to one location (point) 
        public Location Location { get; set; }
    }
}
