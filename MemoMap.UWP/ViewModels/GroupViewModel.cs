using MemoMap.Domain;
using MemoMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace MemoMap.UWP.ViewModels
{
    public class GroupViewModel: BindableBase
    {
        public Group Group { get; set; }

        private BitmapImage _uploadedImage;
        public ObservableCollection<Group> Groups { get; set; }

        public GroupViewModel()
        {
            Group = new Group();
            Groups = new ObservableCollection<Group>();
        }

        public BitmapImage UploadedImage 
        {
            get => _uploadedImage;
            set => SetField(ref _uploadedImage, value);
        }

        public async Task LoadAllAsync()
        {
            List<Group> groups = await App.
                UnitOfWork.
                GroupRepository.
                FindAllJoinedGroupsAsync(App.UserViewModel.LoggedUser.Id);

            Groups.Clear();
            foreach (Group g in groups)
            {
                Groups.Add(g);
            }
        }


        internal async Task InsertAsync()
        {
            Group.Date = DateTime.Now;
            Group newGroup = await App.UnitOfWork.GroupRepository.CreateAsync(Group);
            await App.UnitOfWork.GroupUserRepository.CreateAsync(
                new GroupUser
                {
                    GroupId = newGroup.Id,
                    UserId = App.UserViewModel.LoggedUser.Id,
                }
            );
        }

        internal async Task InsertOrUpdate()
        {
            var newGroup = await App.UnitOfWork.GroupRepository.UpsertAsync(Group);

            if (newGroup != null)
            {
              await App.UnitOfWork.GroupUserRepository.CreateAsync(
                    new GroupUser
                    {
                        GroupId = newGroup.Id,
                        UserId = App.UserViewModel.LoggedUser.Id,
                    }
               );
            }
        }

        internal async Task DeleteAsync(Group group)
        {
            await App.UnitOfWork.GroupRepository.DeleteAsync(group);
            Groups.Remove(group);
        }

        internal async Task EditAsync()
        {
            await App.UnitOfWork.GroupRepository.UpdateAsync(Group);
        }
    }
}
