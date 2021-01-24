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

namespace MemoMap.UWP.ViewModels
{
    public class MapViewModel : BindableBase
    {
        public Map Map { get; set; }

        public ObservableCollection<UserMap> Maps { get; set; }
        //public ObservableCollection<Map> Maps { get; set; }

        //public MapFormValidation MapFormValidation { get; set; }

        public MapViewModel()
        {
            Map = new Map();
            Maps = new ObservableCollection<UserMap>();
            //Maps = new ObservableCollection<Map>();

            //MapFormValidation = new MapFormValidation();
        }

        public async Task LoadAllAsync()
        {
            //List<Map> maps = await App.UnitOfWork.MapRepository.FindAllAsync();
            List<UserMap> maps = await App.UnitOfWork
                .UserMapRepository
                .FindAllJoinedMapsAsync(App.UserViewModel.LoggedUser.Id);

            Maps.Clear();
            foreach (UserMap m in maps)
            {
                Maps.Add(m);
            }
            //Maps.Clear();
            //foreach (Map m in maps)
            //{
            //    Maps.Add(m);
            //}
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
        //internal async Task DeleteAsync(Map map)
        //{
        //    await App.UnitOfWork.MapRepository.DeleteAsync( Map);
        //    Maps.Remove(map);
        //}

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
            //else if (newMap == null)
            //{
            //    // inform user that empty value will not be inserted

            //}
        }
    }
}
