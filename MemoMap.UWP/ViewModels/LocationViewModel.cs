using MemoMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.UWP.ViewModels
{
    public class LocationViewModel
    {
        public Location Location { get; set; }

        public MapViewModel MapViewModel { get; set; }

        public LocationViewModel()
        {
            Location = new Location();
            MapViewModel = new MapViewModel();
        }

        internal async Task InsertAsync(string lat, string longt, int mapId)
        {
            var lastPoint = await App.UnitOfWork.LocationRepository.CreateAsync(new Location
            { Latitude = lat, Longitude = longt });

            // insert into MapLocation 
            await App.UnitOfWork.MapLocationRepository.CreateAsync(new MapLocation { LocationId = lastPoint.Id, MapId = mapId });

            var _pointId = lastPoint.Id; // for the testing purposes
            var _mapId = mapId;
        }
    }
}
