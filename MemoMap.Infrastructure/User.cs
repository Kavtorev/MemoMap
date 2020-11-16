using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure
{
    public class User
    {
        /*
         user_id int 
         email string 
         password string
         role string
        */
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // user can be part of many groups
        public List<Group> Groups { get; set; }
    }
}
