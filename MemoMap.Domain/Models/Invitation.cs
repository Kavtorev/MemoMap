using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Domain.Models
{
    public class Invitation: Entity
    {
        public int InvitingId { get; set; }
        public int InvitedId { get; set; }
        public int GroupId { get; set; }
        public DateTime Date { get; set; }

        public User Inviting { get; set; }
        public User Invited { get; set; }
        public Group Group { get; set; }

        public string InvitationTitle 
        {
            get => $"User '{Inviting.Username}' proposes to join the '{Group.Name}'."; 
        }

        public Invitation()
        {
            Date = DateTime.Now;
        }
    }
}
