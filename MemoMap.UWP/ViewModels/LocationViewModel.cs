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
        public string _longtitute;
        public string _latitude;

        public MapViewModel MapViewModel { get; set; }

        public LocationViewModel()
        {
            Location = new Location();
            MapViewModel = new MapViewModel();
        }

        internal async Task InsertAsync(string lat, string longt)
        {
            await App.UnitOfWork.LocationRepository.CreateAsync(new Location
            { Latitude = lat, Longitude = longt });
        }
    }
}
