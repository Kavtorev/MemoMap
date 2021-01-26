using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Domain.Repositories
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<List<Note>> FindAssociatedNote(int noteId);
    }
}
