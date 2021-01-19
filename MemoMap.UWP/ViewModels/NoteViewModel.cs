using MemoMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.UWP.ViewModels
{
    public class NoteViewModel
    {
        public Note Note { get; set; }

        public ObservableCollection<Note> Notes { get; set; }

        public NoteViewModel()
        {
            Note = new Note();
            Notes = new ObservableCollection<Note>();
        }


    }
}
