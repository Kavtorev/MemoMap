using System;
using MemoMap.Domain;
using MemoMap.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace MemoMapConsole
{
    public class Program
    {
        static string connectionString = "Server=localhost; Initial Catalog=memo-map; Integrated Security = True; User ID=memomapAdmin; Password=admin; Connect Timeout = 30;";
        static void Main(string[] args)
        {
            DbContextOptionsBuilder<MemoMapDbContext> optionsBuilder = new DbContextOptionsBuilder<MemoMapDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            IUnitOfWork UOW = new UnitOfWork(optionsBuilder.Options);
        }
    }
}
