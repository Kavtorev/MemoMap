﻿using MemoMap.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.UWP.ViewModels
{
    public class NoteViewModel
    {
        private Note _Note;

        public Note Note { get; set; }

        public NoteViewModel()
        {
            Note = new Note();
        }

        internal async Task CreateNote()
        {

        }
    }
}
