using MemoMap.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure
{
    public class MemoMapDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        // connection string
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost; Initial Catalog=memo-map; Integrated Security = True; User ID=memomapAdmin; Password=admin; Connect Timeout = 30;");
        }
    }
}
