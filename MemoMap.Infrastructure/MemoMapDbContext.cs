using MemoMap.Domain;
using MemoMap.Domain.Models;
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
        public DbSet<Map> Maps { get; set; }
        public DbSet<Location> Points { get; set; }
        public DbSet<Route> Routes { get; set; }

        // raw DbContext
        public MemoMapDbContext() { }
        public MemoMapDbContext(DbContextOptions options):base(options) { }


        // connection string

        // nevertheless we pass custom options to MemoMapDbContext, we need to specify db provider to make migrations
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost; Initial Catalog=memo-map; Integrated Security = True; User ID=memomapAdmin; Password=admin; Connect Timeout = 30;");
        }
    }
}
