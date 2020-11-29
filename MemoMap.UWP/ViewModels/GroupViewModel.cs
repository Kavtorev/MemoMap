using MemoMap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.UWP.ViewModels
{
    public class GroupViewModel
    {
        public Group Group { get; set; }

        public GroupViewModel()
        {
            Group = new Group();
        }

        internal async Task InsertAsync()
        {
            await App.UnitOfWork.GroupRepository.CreateAsync(Group);
        }

        internal void Insert()
        {
            App.UnitOfWork.GroupRepository.Create(Group);
        }
        
    }
}
