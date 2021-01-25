using MemoMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.UWP.ViewModels
{
    public class MapLocationViewModel
    {
        public Map Map { get; set; }
        public Location Location { get; set; }
        
        public MapViewModel MapViewModel { get; set; }
        public LocationViewModel LocationViewModel { get; set; }

        public MapLocationViewModel()
        {
            this.MapViewModel = new MapViewModel();
            this.LocationViewModel = new LocationViewModel();
        }

        internal async Task InsertAsync(string lat, string longt)
        {
            await App.UnitOfWork.LocationRepository.CreateAsync(new Location
            { Latitude = lat, Longitude = longt });

            //// create async for the adjacent table (given params: MapId and LocationId
            //await App.UnitOfWork.MapLocationRepository.CreateAsync(
            //    new MapLocation
            //    {
            //        MapId = MapViewModel.Map.Id,
            //        // It probably will not work because I initialized 
            //        // new LocatioViewModel and _pointId will be empty
            //        LocationId = LocationViewModel._pointId
            //    });
        }
    }
}
