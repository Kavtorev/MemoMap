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
        public DbSet<Note> Notes { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<UserMap> UserMaps { get; set; }

        // raw DbContext
        public MemoMapDbContext() { }
        public MemoMapDbContext(DbContextOptions options):base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().Ignore(g => g.FormattedDate);

            modelBuilder.Entity<GroupUser>().HasKey(bc => new { bc.GroupId, bc.UserId });

            modelBuilder.Entity<GroupUser>()
                .HasOne(bc => bc.Group)
                .WithMany(b => b.GroupUsers)
                .HasForeignKey(bc => bc.GroupId);

            modelBuilder.Entity<GroupUser>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.GroupUsers)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserMap>().HasKey(bc => new { bc.UserId, bc.MapId });

            modelBuilder.Entity<UserMap>()
               .HasOne(bc => bc.User)
               .WithMany(b => b.UserMaps)
               .HasForeignKey(bc => bc.UserId);

            modelBuilder.Entity<UserMap>()
                .HasOne(bc => bc.Map)
                .WithMany(c => c.UserMaps)
                .HasForeignKey(bc => bc.MapId);

            modelBuilder.Entity<MapLocation>().HasKey(bc => new { bc.MapId, bc.LocationId });

            modelBuilder.Entity<MapLocation>()
               .HasOne(bc => bc.Map)
               .WithMany(b => b.MapLocations)
               .HasForeignKey(bc => bc.MapId);

            modelBuilder.Entity<MapLocation>()
                .HasOne(bc => bc.Location)
                .WithMany(c => c.MapLocations)
                .HasForeignKey(bc => bc.LocationId);

            modelBuilder.Entity<MapRoute>().HasKey(bc => new { bc.MapId, bc.RouteId });

            modelBuilder.Entity<MapRoute>()
               .HasOne(bc => bc.Map)
               .WithMany(b => b.MapRoutes)
               .HasForeignKey(bc => bc.MapId);

            modelBuilder.Entity<MapRoute>()
                .HasOne(bc => bc.Route)
                .WithMany(c => c.MapRoutes)
                .HasForeignKey(bc => bc.RouteId);

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
