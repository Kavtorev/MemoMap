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
    public sealed partial class ViewMapsPage : Page
    {
        public MapViewModel MapViewModel { get; set; }

        public ViewMapsPage()
        {
            this.InitializeComponent();
            MapViewModel = new MapViewModel();
        }

        private void deleteMap_Click(object sender, RoutedEventArgs e)
        {
            // add in the future commit
        }

        private void editMap_Click(object sender, RoutedEventArgs e)
        {
            // add in the future commit
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await MapViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }

        private void createNewMap_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateMapPage));
        }
    }
}
