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

namespace MemoMap.UWP.Views.LocationViews
{
    public sealed partial class MapPage : Page
    {
        internal string MapToken = "y5u3jsMhdvyHKgngvqEi~HaMfdHCJ_mjaxrQcErYZhA~AndzA0R4aQZ8y5Oyrpzxme12X5U6j_ZlF7SeczHMd6T1LNmoIpvvRpUZWxdghm9M";
        private ObservableCollection<MapElement> _points;
        public int _currentMap;
        public List<MapLocation> _locationsAssociated;
        public List<MapLocation> _locationsData;
        public List<Note> _notesData;
        public MapViewModel MapViewModel { get; set; }
        public NoteViewModel NoteViewModel { get; set; }
        public LocationViewModel LocationViewModel { get; set; }

        public MapPage()
        {
            this.InitializeComponent();
            _points = new ObservableCollection<MapElement>();
            this.MapViewModel = new MapViewModel();
            this.NoteViewModel = new NoteViewModel();
            this.LocationViewModel = new LocationViewModel();

            _locationsAssociated = new List<MapLocation>();
            //_locationsData = new List<MapLocation>();
            _notesData = new List<Note>();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            // check all LocationId related with the map that is currently used to work with
            // and append to the _points list that will be used to fill the POIs on the map
            if (e.Parameter != null)
            {
                var model = (e.Parameter as UserMap).Map;
                MapViewModel.Map = model; // the current map will be loaded in MapViewModel.Map
                _currentMap = model.Id; // current mapId

                // locationIds + locationsData (longtitute / latitute)
                _locationsAssociated = await MapViewModel.GetLocationsAssociatedWithMap(_currentMap);
                _locationsData = await MapViewModel.GetLocationsDataAssociatedWithMap(_locationsAssociated);
                

                var landmarks = _points;
                // if locations exists will be displayed on the map
                foreach (MapLocation loc in _locationsAssociated)
                {
                    if (loc != null)
                    {
                        var currentLocation = loc.LocationId;
                        var note = await MapViewModel.GetAssociatedNoteData(currentLocation);

                        // get the longt and lat
                        BasicGeoposition _pos = new BasicGeoposition { Latitude = Convert.ToDouble(loc.Location.Latitude), Longitude = Convert.ToDouble(loc.Location.Longitude) };
                        Geopoint _position = new Geopoint(_pos);

                        var _spaceNeedleIcon = new MapIcon
                        {
                            Location = _position,
                            NormalizedAnchorPoint = new Point(0.5, 1.0),
                            ZIndex = 0,
                            // point will be added with defined name
                            Title = note.Title
                        };

                        landmarks.Add(_spaceNeedleIcon);

                        var LandMarksLayer = new MapElementsLayer
                        {
                            ZIndex = 1,
                            MapElements = landmarks
                        };

                        MemoMap.Layers.Add(LandMarksLayer);
                    }
                    else if (loc == null) // if there are no points in the database related with current map 
                    {
                        return; // exit the loop
                    }
                }



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

        private void OverlayGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            InfoGrid.Visibility = Visibility.Collapsed;
            OverlayGrid.Visibility = Visibility.Collapsed;
        }

        private void editNote_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void deleteLocation_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement b && b.DataContext is Location location)
            {
                await LocationViewModel.DeleteAsync(location);
            }
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            InfoGrid.Visibility = Visibility.Visible;
            OverlayGrid.Visibility = Visibility.Visible;
        }
    }
}
