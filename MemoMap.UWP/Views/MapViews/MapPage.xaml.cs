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
using System.Collections.ObjectModel;
using MemoMap.UWP.ViewModels;
using MemoMap.Domain.Models;

namespace MemoMap.UWP.Views.Location
{
    public sealed partial class MapPage : Page
    {
        internal string MapToken = "y5u3jsMhdvyHKgngvqEi~HaMfdHCJ_mjaxrQcErYZhA~AndzA0R4aQZ8y5Oyrpzxme12X5U6j_ZlF7SeczHMd6T1LNmoIpvvRpUZWxdghm9M";
        private ObservableCollection<MapElement> _points;
        public int _currentMap;
        public MapViewModel MapViewModel { get; set; }

        public MapPage()
        {
            this.InitializeComponent();
            _points = new ObservableCollection<MapElement>();
            this.MapViewModel = new MapViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // check all LocationId related with the map that is currently used to work with
            // and append to the _points list that will be used to fill the POIs on the map
            if (e.Parameter != null)
            {
                var model = (e.Parameter as UserMap).Map;
                MapViewModel.Map = model; // the current map will be loaded in MapViewModel.Map
                _currentMap = model.Id; // current mapId
                base.OnNavigatedTo(e);
            }
        }

        private async void MemoMap_MapTapped(MapControl sender, MapInputEventArgs args)
        {
            var GeoPosition = args.Location.Position;
            var landmarks = _points;

            // store picked points in the MapViewModel
            var _latitude = GeoPosition.Latitude.ToString();
            var _longtitute = GeoPosition.Longitude.ToString();
            
            // open pop up to ask user for additional information about point 
            PointAdding pnt = new PointAdding(_longtitute, _latitude, _currentMap);
            await pnt.ShowAsync();

            // get provided name of the point
            var title = pnt._pointname;
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
        }
    }
}
