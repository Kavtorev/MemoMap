using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Infrastructure.Repositories
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(MemoMapDbContext db) : base(db)
        {

        }

        public async Task<List<Note>> FindAssociatedNote(int noteId)
        {
            return await _dbContext.Notes
                .Where(loc => loc.LocationId == noteId)
                .ToListAsync();
        }
    }
}
