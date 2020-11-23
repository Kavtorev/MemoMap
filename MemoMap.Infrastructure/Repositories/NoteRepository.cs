using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.Repositories
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        public NoteRepository(MemoMapDbContext db) : base(db)
        {

        }
    }
}
