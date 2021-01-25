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
using MemoMap.UWP.ViewModels;


namespace MemoMap.UWP.Views.Location
{
    public sealed partial class PointAdding : ContentDialog
    {
        internal string pointname, _lat, _long;
        internal int _id;

        public NoteViewModel NoteViewModel { get; set; }

        public LocationViewModel LocationViewModel { get; set; }

        public MapViewModel MapViewModel { get; set; }

        public PointAdding(string longtitute="", string latitude="", int mapId=0)
        {
            this.InitializeComponent();
            NoteViewModel = new NoteViewModel();
            LocationViewModel = new LocationViewModel();
            MapViewModel = new MapViewModel();

            _lat = latitude; _long = longtitute; _id = mapId;
        }

        private async void SavePointClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            pointname = PointName.Text;
            
            // insert the point to the Locations table
            await LocationViewModel.InsertAsync(_lat, _long, _id);
        }

        private void CancelPointAddingClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            PointName.Text = ""; // clear the text of pointname to exit from MemoMap_MapTapped properly
        }
    }
}
