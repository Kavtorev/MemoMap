using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Infrastructure.Repositories
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(MemoMapDbContext db) : base(db)
        {

        }

        Task<Note> INoteRepository.AddNewNoteAsync(string Title, string Description)
        {
            throw new NotImplementedException();
        }
    }
}
