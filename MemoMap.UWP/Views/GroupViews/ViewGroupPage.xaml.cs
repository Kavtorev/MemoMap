using MemoMap.UWP.ViewModels;
using MemoMap.Domain.Models;
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
    public sealed partial class ViewGroupPage : Page
    {
        public GroupViewModel GroupViewModel { get; set; }
        public ViewGroupPage()
        {
            this.InitializeComponent();
            GroupViewModel = new GroupViewModel();
            App.MainViewModel.setTitle("The lists of groups related to you.");
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await GroupViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }

        private async void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement b && b.DataContext is GroupUser g2u)
            {
                await GroupViewModel.DeleteAsync(g2u);
            }

        }

        private void editGroup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement b && b.DataContext is GroupUser g2u)
            {
                this.Frame.Navigate(typeof(CreateGroupPage), g2u);
            }
        }
        private void createNewGroup_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateGroupPage));
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            GroupUser g2u = (GroupUser)e.ClickedItem;
            this.Frame.Navigate(typeof(GroupPage), g2u);
        }

        private async void LeaveGroup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement b && b.DataContext is GroupUser g2u)
            {
                await GroupViewModel.LeaveTheGroup(g2u);
                await GroupViewModel.LoadAllAsync("normalUser");
            }
        }

        private async void NormalUserButton_Click(object sender, RoutedEventArgs e)
        {
            await GroupViewModel.LoadAllAsync("normalUser");
        }

        private async void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            await GroupViewModel.LoadAllAsync();
        }
    }
}
