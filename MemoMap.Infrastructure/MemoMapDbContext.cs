using MemoMap.Domain;
using MemoMap.Domain.Models;
using MemoMap.Infrastructure.EntityConfigurations;
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
        public DbSet<Location> Locations { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<UserMap> UserMaps { get; set; }

        // raw DbContext
        public MemoMapDbContext() { }
        public MemoMapDbContext(DbContextOptions options):base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupEntityConfiguration());
            modelBuilder.ApplyConfiguration(new GroupUserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MapLocationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MapRouteEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserMapEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }

        /*
         Connection string
        */

        // nevertheless we pass custom options to MemoMapDbContext, we need to specify db provider to make migrations
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost; Initial Catalog=memo-map; Integrated Security = True; User ID=memomapAdmin; Password=admin; Connect Timeout = 30;");
        }
    }
}
