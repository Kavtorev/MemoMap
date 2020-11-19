using System;
using MemoMap.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MemoMapConsole
{
    public class Program
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
