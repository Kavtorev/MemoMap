using MemoMap.Domain;
using MemoMap.Domain.Models;
using MemoMap.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MemoMap.UWP.Views.GroupViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GroupPage : Page
    {

        public GroupViewModel GroupViewModel { get; set; }
        public UserViewModel UserViewModel { get; set; }

        public GroupPage()
        {
            this.InitializeComponent();
            GroupViewModel = new GroupViewModel();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                GroupViewModel.Group = (e.Parameter as GroupUser).Group;
                GroupViewModel.AdminFunctionsVisibility = (e.Parameter as GroupUser).IsAdmin;

                var users = await GroupViewModel.LoadUsersAsync();
                if (users.Count() > 1)
                {
                    GroupViewModel.LoadGroupAdmin();
                }
                else if (users.Count() == 1)
                {
                    GroupViewModel.GroupAdmin = users[0];
                }
                base.OnNavigatedTo(e);
            }

        }

        private async void InviteButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var errs = GroupViewModel.ValidateUsername();
            if (string.IsNullOrEmpty(errs))
            {
                if (await GroupViewModel.DoesUserExist()
                    && !(await GroupViewModel.WasAlreadyInvited())
                    && !(await GroupViewModel.AlreadyPariticipates()))
                {
                    await GroupViewModel.InviteUser();
                    InvitationalFlyout.Hide();
                }
            }
        }

        private void UsernameInput_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                sender.Text = args.ChosenSuggestion.ToString();
            }
        }

        private void UsernameInput_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                sender.Text = args.SelectedItem.ToString();
            }

        }

        private async void UsernameInput_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (sender.Text != null)
            {

                var suggestions = await GroupViewModel.LoadUsersByUsernameStartWith();
                sender.ItemsSource = suggestions;
            }
            
                
        }

        private void UserProfile_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender is FrameworkElement b && GroupViewModel.AdminFunctionsVisibility 
                && b.DataContext is User user)
            {
                if (user.Id != App.UserViewModel.LoggedUser.Id)
                    b.ContextFlyout.ShowAt(b);
            }
        }

        private void Promote_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Kick_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement u && u.DataContext is User user)
            {
                await GroupViewModel.KickUser(user);
            }
        }
    }
}
    