using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain
{
    public class Group : Entity
    {
        /*
         group_id INT
         name string
        */
        public string Name { get; set; }

        // many users can be in one group
        public List<User> Users { get; set; }
    }
}
