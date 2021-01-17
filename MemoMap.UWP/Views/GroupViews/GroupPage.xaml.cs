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
                GroupViewModel.Group = e.Parameter as Group;

                var users = await GroupViewModel.LoadUsersAsync();
                if (users.Count() > 1)
                {
                    GroupViewModel.GetGroupAdmin();
                }
                else if (users.Count() == 1)
                {
                    GroupViewModel.GroupAdmin = users[0];
                }
                base.OnNavigatedTo(e);
            }

            

        }


    }
}
