using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Models
{
    public class Group : Entity
    {

        public Group()
        {
            GroupUsers = new List<GroupUser>();
            Date = DateTime.Now;
        }
        /*
         group_id INT
         name string
        */
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public byte[] Thumbnail { get; set; }

        public string FormattedDate
        {
            get => $"joined on: {Date.ToString("dddd, dd MMMM yyyy")}";

        }

        // many users can be in a one group
        public ICollection<GroupUser> GroupUsers { get; set; }

        // one group can include many maps
        public ICollection<Map> Maps { get; set; }
    }
}
