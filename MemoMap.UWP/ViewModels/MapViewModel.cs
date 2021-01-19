using MemoMap.Domain.Models;
using MemoMap.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.UWP.ViewModels
{
    public class MapViewModel
    {
        public Map Map { get; set; }

        public ObservableCollection<Map> Maps { get; set; }

        public MapViewModel()
        {
            Map = new Map();
            Maps = new ObservableCollection<Map>();
        }

        public async Task LoadAllAsync()
        {
            List<Map> maps = await App.UnitOfWork.MapRepository.FindAllAsync();
            Maps.Clear();
            foreach(Map m in maps)
            {
                Maps.Add(m);
            }
        }

        internal async Task InsertAsync()
        {
            await App.UnitOfWork.MapRepository.CreateAsync(Map);
        }

        internal async Task DeleteAsync(Map map)
        {
            await App.UnitOfWork.MapRepository.DeleteAsync(map);
            Maps.Remove(map);
        }

        internal async Task EditAsync()
        {
            await App.UnitOfWork.MapRepository.UpdateAsync(Map);
        }

        internal async Task InsertOrUpdate()
        {
            var newMap = App.UnitOfWork.MapRepository.UpdateAsync(Map);
            if (newMap != null)
                await App.UnitOfWork.MapRepository.CreateAsync(Map);
        }
    }
}
