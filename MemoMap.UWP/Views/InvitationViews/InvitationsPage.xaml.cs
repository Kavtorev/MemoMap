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

namespace MemoMap.UWP.Views.InvitationViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InvitationsPage : Page
    {
        public InvitationsPage()
        {
            this.InitializeComponent();
            InvitationViewModel = new InvitationViewModel();
            App.MainViewModel.setTitle("The list of groups you could join.");
        }

        public InvitationViewModel InvitationViewModel { get; private set; }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await InvitationViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }

        private async void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement b && b.DataContext is Invitation invitation)
            {
                await InvitationViewModel.AcceptGroupInvite(invitation);
            }
        }

        private async void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement b && b.DataContext is Invitation invitation )
            {
                await InvitationViewModel.DeleteAsync(invitation);
            }
        }
    }
}
