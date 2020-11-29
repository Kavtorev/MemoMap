using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Models
{
    public class UserMap
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int MapId { get; set; }
        public Map Map { get; set; }
    }

}
