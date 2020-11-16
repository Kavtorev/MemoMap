using System;
using MemoMap.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MemoMapConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MemoMapDbContext db = new MemoMapDbContext())
            {
                db.Database.Migrate();
            }
        }
    }
}
