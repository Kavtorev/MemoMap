using MemoMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.UWP.ViewModels
{
    public class InvitationViewModel
    {

        public ObservableCollection<Invitation> Invites { get; set; }

        public InvitationViewModel()
        {
            Invites = new ObservableCollection<Invitation>();
        }


        public async Task LoadAllAsync()
        {
            var userId = App.UserViewModel.LoggedUser.Id;
            List<Invitation> res = 
                await App.UnitOfWork.InvitationRepository.FindAllReceivedInvites(userId);
            Invites.Clear();
            foreach (Invitation invite in res)
            {
                Invites.Add(invite);
            }
        }

        internal async Task DeleteAsync(Invitation invitation)
        {
            await App.UnitOfWork.InvitationRepository.DeleteAsync(invitation);
            Invites.Remove(invitation);
        }

        internal async Task AcceptGroupInvite(Invitation invitation)
        {
            await App.UnitOfWork.GroupUserRepository.CreateAsync(
                new GroupUser
                {
                    GroupId = invitation.GroupId,
                    UserId = invitation.InvitedId,
                });

            await this.DeleteAsync(invitation);
        }
    }
}
