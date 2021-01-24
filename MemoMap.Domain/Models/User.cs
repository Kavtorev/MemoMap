using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Models
{
    public class User : Entity
    {
        public User()
        {
            GroupUsers = new List<GroupUser>();
        }
        /*
         username string 
         email string
         password string
         isAdmin boolean 
        */
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }

        // user can be part of many groups
        public ICollection<GroupUser> GroupUsers { get; set; }
        // Invitations which were sent by the inviting person.
        public ICollection<Invitation> InvitingInvitations { get; set; }
        // Invitations which were received by the invited person.
        public ICollection<Invitation> InvitedInvitations { get; set; }
        public ICollection<UserMap> UserMaps { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}
