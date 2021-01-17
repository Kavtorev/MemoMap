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
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await GroupViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }

        private async void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement b && b.DataContext is Group group)
            {
                await GroupViewModel.DeleteAsync(group);
            }

        }

        private void editGroup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement b && b.DataContext is Group group)
            {
                this.Frame.Navigate(typeof(CreateGroupPage), group);
            }
        }
        private void createNewGroup_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateGroupPage));
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Group g = (Group)e.ClickedItem;
            this.Frame.Navigate(typeof(GroupPage), g);
        }
    }
}
