using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure
{
    public class Group
    {
        /*
         group_id INT
         name string
        */
        public int GroupId { get; set; }
        public string Name { get; set; }

        // many users can be in one group
        public List<User> Users { get; set; }
    }
}
