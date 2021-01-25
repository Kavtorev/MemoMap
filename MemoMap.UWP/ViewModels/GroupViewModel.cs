using MemoMap.Domain;
using MemoMap.Domain.Models;
using MemoMap.Domain.Services;
using MemoMap.Infrastructure;
using MemoMap.Domain.Validation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Data;

namespace MemoMap.UWP.ViewModels
{
    public class GroupViewModel : BindableBase
    {
        public Group Group { get; set; }
        public ObservableCollection<Map> Maps;
        private BitmapImage _uploadedImage;
        private string _invitedUsername;
        public GroupPageService GroupPageService { get; set; }
        private User _groupAdmin;
        public ObservableCollection<GroupUser> Groups { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<User> Moderators { get; set; }

        public User InvitedUser { get; set; }


        private string _validationErrors;

        public string ValidationErrors
        {
            get => _validationErrors;
            set => SetField(ref _validationErrors, value);
        }

        public string InvitedUsername
        {
            get => _invitedUsername;
            set => SetField(ref _invitedUsername, value);
        }

        public User GroupAdmin
        {
            get => _groupAdmin;
            set => SetField(ref _groupAdmin, value);
        }

        public bool AdminFunctionsVisibility { get; set; }
        public bool ModeratorFunctionsVisibility { get; set; }

        public GroupViewModel()
        {
            Group = new Group();
            Groups = new ObservableCollection<GroupUser>();
            Users = new ObservableCollection<User>();
            Maps = new ObservableCollection<Map>();
            Moderators = new ObservableCollection<User>();

            DbContextOptionsBuilder<MemoMapDbContext> options =
               new DbContextOptionsBuilder<MemoMapDbContext>();

            options.UseSqlServer(App.connectionString);
            GroupPageService = new GroupPageService(new UnitOfWork(options.Options));
        }

        internal async Task LoadModeratorsAsync()
        {
            List<User> moders = await App.UnitOfWork.GroupRepository.FindAllGroupModerators(Group.Id);
            _updatedObservableCollection(Moderators, moders);
        }

        internal async Task LoadMapsAsync()
        {
            List<Map> maps = await App.UnitOfWork.MapRepository.FindMapBelongGroup(Group.Id);
            _updatedObservableCollection(Maps, maps);
        }

        public BitmapImage UploadedImage
        {
            get => _uploadedImage;
            set => SetField(ref _uploadedImage, value);
        }

        public void LoadGroupAdmin()
        {
            GroupAdmin = GroupPageService.GetGroupAdmin(Group.Id);
        }

        internal string ValidateUsername()
        {
            ValidationErrors = "";
            ValidationErrors = GroupPageService.CheckUsernameValidity(InvitedUsername);
            return ValidationErrors;
        }

        internal async Task LeaveTheGroup(GroupUser g2u)
        {
            await App.UnitOfWork.GroupUserRepository.DeleteAsync(g2u);
        }

        internal async Task<bool> WasAlreadyInvited()
        {
            var res =
                await App.UnitOfWork.InvitationRepository.FindByInvitedGroupId(InvitedUser.Id, Group.Id);
            if (res == null) return false;
            ValidationErrors = $"User '{InvitedUsername}' was already invited to join this group.";
            return true;
        }


        internal async Task<Invitation> InviteUser()
        {
            return await App.UnitOfWork.InvitationRepository.CreateAsync(
                new Invitation
                {
                    GroupId = Group.Id,
                    InvitingId = App.UserViewModel.LoggedUser.Id,
                    InvitedId = InvitedUser.Id,
                });
        }


        public async Task<bool> DoesUserExist()
        {
            InvitedUser = await App.UnitOfWork.UserRepository.FindByUsernameAsync(InvitedUsername);
            if (InvitedUser != null) return true;
            ValidationErrors = "User doesn't exist";
            return false;
        }

        public async Task<bool> AlreadyPariticipates()
        {
            var res = await App.UnitOfWork.GroupUserRepository
                .FindByUserGroupId(InvitedUser.Id, this.Group.Id);

            if (res == null) return false;
            ValidationErrors = $"User '{InvitedUsername}' already participates in this group.";
            return true;
        }

        internal async Task KickUser(User user)
        {
            await App.UnitOfWork.GroupUserRepository.DeleteAsync(
                await App.UnitOfWork.GroupUserRepository.FindByUserGroupId(user.Id, Group.Id)
                );
            Users.Remove(user);
        }

        internal async Task<ObservableCollection<User>> LoadUsersByUsernameStartWith()
        {
            var res = await
                App.UnitOfWork.UserRepository.FindUserByUsernameStartWith(InvitedUsername);
            return new ObservableCollection<User>(res);
        }

        public async Task LoadAllAdmin()
        {
            List<GroupUser> groups =
                await App.UnitOfWork.GroupUserRepository
                .FindAllAdminGroupsAsync(App.UserViewModel.LoggedUser.Id);
            _updatedObservableCollection(Groups, groups);
        }

        public async Task LoadAllNormalUser()
        {
            List<GroupUser> groups =
                await App.UnitOfWork.GroupUserRepository
                .FindAllNormalUserGroupsAsync(App.UserViewModel.LoggedUser.Id);
            _updatedObservableCollection(Groups, groups);
        }

        private void _updatedObservableCollection<T>
            (ObservableCollection<T> observableCollection, List<T> newCollection)
        {
            observableCollection.Clear();
            foreach (T entity in newCollection) observableCollection.Add(entity);
        }


        internal async Task<ObservableCollection<User>> LoadUsersAsync()
        {
            List<User> users = await App.
                UnitOfWork.
                GroupRepository.
                FindAllGroupUsers(Group.Id);

            _updatedObservableCollection(Users, users);
            return Users;
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
                          IsAdmin = true,
                          IsModerator = true,
                      }
                 );
            }
        }

        internal async Task DeleteAsync(GroupUser group)
        {
            await App.UnitOfWork.GroupRepository.DeleteAsync(group.Group);
            Groups.Remove(group);
        }

        internal async Task EditAsync()
        {
            await App.UnitOfWork.GroupRepository.UpdateAsync(Group);
        }
    }
}
