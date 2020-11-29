using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain
{
    public class User : Entity
    {
        /*
         user_id int 
         email string 
         password string
         role string
        */
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // user can be part of many groups
        public ICollection<GroupUser> GroupUsers { get; set; }
        public ICollection<UserMap> UserMaps { get; set; }
    }
}
