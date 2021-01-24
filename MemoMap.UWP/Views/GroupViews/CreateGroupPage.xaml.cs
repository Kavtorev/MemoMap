using MemoMap.Domain.Models;
using MemoMap.UWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
    public sealed partial class CreateGroupPage : Page
    {
        public GroupViewModel GroupViewModel { get; set; }
        public MainViewModel MainViewModel { get; set; }

        public CreateGroupPage()
        {
            this.InitializeComponent();
            GroupViewModel = new GroupViewModel();
            MainViewModel = new MainViewModel();
            App.MainViewModel.setTitle("Originate a new group");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var cameFrom = this.Frame.BackStack.LastOrDefault();
            if (cameFrom != null && e.Parameter != null)
            {
                if (cameFrom.SourcePageType == typeof(GroupPage))
                {
                    GroupViewModel.Group = e.Parameter as Group;
                }
                else
                {
                    GroupViewModel.Group = (e.Parameter as GroupUser).Group;
                }
            }
            base.OnNavigatedTo(e);
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await GroupViewModel.InsertOrUpdate();

            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
                this.Frame.GoBack();
        }

        private async void Thumbnail_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var file = await MainViewModel.PickImageFileAsync();
            if (file != null)
            {
                GroupViewModel.Group.Thumbnail = await MainViewModel.LoadFileByteArray(file);
                GroupViewModel.UploadedImage = await MainViewModel.LoadImageFile(file);
            }    
        }
    }
}
