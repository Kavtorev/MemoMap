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

namespace MemoMap.UWP.Views.MapViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateMapPage : Page
    {
        public MapViewModel MapViewModel { get; set; }

        public CreateMapPage()
        {
            this.InitializeComponent();
            MapViewModel = new MapViewModel();
            App.MainViewModel.setTitle("Originate a new Map");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                var model = (e.Parameter as UserMap).Map;
                MapViewModel.Map = model;
                base.OnNavigatedTo(e);
            }
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            await MapViewModel.InsertOrUpdate();

            if (this.Frame.CanGoBack) { this.Frame.GoBack(); }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack) this.Frame.GoBack();
        }
    }
}
