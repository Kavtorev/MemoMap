using MemoMap.Domain.Models;
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

        //public Group(string name)
        //{
        //    Name = name;
        //}

        // many users can be in one group
        public ICollection<GroupUser> GroupUsers { get; set; }

        // one group can include many maps
        public ICollection<Map> Maps { get; set; }
    }
}
