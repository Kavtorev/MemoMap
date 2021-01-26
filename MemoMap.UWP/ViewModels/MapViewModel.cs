using MemoMap.Domain;
using MemoMap.Domain.Models;
using MemoMap.Domain.Validation;
using MemoMap.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls.Maps;

namespace MemoMap.UWP.ViewModels
{
    public class MapViewModel : BindableBase
    {
        public Map Map { get; set; }

        public ObservableCollection<UserMap> Maps { get; set; }
        public ObservableCollection<MapLocation> Locations { get; set; }
        public ObservableCollection<MapElement> _points;
        public List<int> _locations;
        public List<int> _notes;

        //public MapFormValidation MapFormValidation { get; set; }

        public MapViewModel()
        {
            Map = new Map();
            Maps = new ObservableCollection<UserMap>();
            _points = new ObservableCollection<MapElement>();
            _locations = new List<int>();
            _notes = new List<int>();

            //MapFormValidation = new MapFormValidation();
        }

        public async Task LoadAllAsync()
        {
            List<UserMap> maps = await App.UnitOfWork
                .UserMapRepository
                .FindAllJoinedMapsAsync(App.UserViewModel.LoggedUser.Id);

            Maps.Clear();
            foreach (UserMap m in maps)
            {
                Maps.Add(m);
            }
        }

        //private void _updatedObservableCollection<T>
        //    (ObservableCollection<T> observableCollection, List<T> newCollection)
        //{
        //    observableCollection.Clear();
        //    foreach (T entity in newCollection) observableCollection.Add(entity);
        //}

        public async Task<List<MapLocation>> GetLocationsAssociatedWithMap(int mapId)
        {
            List<MapLocation> locations = await App.UnitOfWork
                .MapLocationRepository
                .FindAllRelatedLocationsAsync(mapId);
           

            //_updatedObservableCollection(Locations, locations);
            return locations;
        }

        public async Task<List<Location>> GetLocationsDataAssociatedWithMap(List<MapLocation> locationsData)
        {
            foreach (MapLocation l in locationsData)
            {
                // store locationId
                await App.UnitOfWork
                    .LocationRepository
                    .FindPositionAssociatedWithLocationId(l);

                _locations.Add(l.LocationId);
            }
            return null;
        }

        public async Task<List<Note>> GetAssociatedNoteData(List<int> noteData)
        {
            foreach (int LocationIdentifier in noteData)
            {
                // store noteId associated with locationId 
                await App.UnitOfWork
                    .NoteRepository
                    .FindAssociatedNote(LocationIdentifier);
            }
            return null;
        }

        internal async Task InsertAsync()
        {
            await App.UnitOfWork.MapRepository.CreateAsync(Map);
        }

        internal async Task DeleteAsync(UserMap map)
        {
            await App.UnitOfWork.MapRepository.DeleteAsync(map.Map);
            Maps.Remove(map);
        }

        internal async Task EditAsync()
        {
            await App.UnitOfWork.MapRepository.UpdateAsync(Map);
        }

        internal async Task InsertOrUpdate()
        {
            var newMap = await App.UnitOfWork.MapRepository.UpsertAsync(Map);

            if (newMap != null)
            {
                await App.UnitOfWork.UserMapRepository.CreateAsync(
                    new UserMap
                    {
                        MapId = newMap.Id,
                        UserId = App.UserViewModel.LoggedUser.Id
                    }
               );
            }
        }
    }
}
