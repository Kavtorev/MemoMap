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
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;



namespace MemoMap.UWP.Views.Location
{
    public sealed partial class MapPage : Page
    {
        public MapPage()
        {
            this.InitializeComponent();
        }

        private async void MemoMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            var GeoPosition = args.Location.Position;
            var landmarks = new List<MapElement>();

            // open pop up to ask user for additional information about point 
            PointAdding pnt = new PointAdding();
            await pnt.ShowAsync();

            // get provided name of the point
            var title = pnt.pointname;
            if (title == null)
                return; // close the method execution without closing the program

            // spec location
            BasicGeoposition pos = new BasicGeoposition { Latitude = GeoPosition.Latitude, Longitude = GeoPosition.Longitude };
            Geopoint position = new Geopoint(pos);

            var spaceNeedleIcon = new MapIcon
            {
                Location = position,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                // point will be added with defined name
                Title = title
            };

            landmarks.Add(spaceNeedleIcon);

            var LandMarksLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = landmarks
            };

            MemoMap.Layers.Add(LandMarksLayer);

            MemoMap.Center = position;
            MemoMap.ZoomLevel = 14;

            // testing the list of currently picked position by the user
            string result = landmarks.ToString();
            positions.Text = result;
        }
    }
}
