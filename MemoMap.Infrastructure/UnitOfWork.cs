using MemoMap.Domain;
using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using MemoMap.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContextOptions Options { get; set; }
        public UnitOfWork(DbContextOptions options)
        {
            Options = options;

            // optional to Update-Database command
            // app crashes if uncommented
            //MemoMapDbContext db = new MemoMapDbContext(options);
            //db.Database.Migrate();

        }

        public IGroupRepository GroupRepository => new GroupRepository(new MemoMapDbContext(Options));

        public ILocationRepository LocationRepository => new LocationRepository(new MemoMapDbContext(Options));

        public IMapRepository MapRepository => new MapRepository(new MemoMapDbContext(Options));

        public IRouteRepository RouteRepository => new RouteRepository(new MemoMapDbContext(Options));

        public IUserRepository UserRepository => new UserRepository(new MemoMapDbContext(Options));

        public INoteRepository NoteRepository => new NoteRepository(new MemoMapDbContext(Options));

        public IGroupUserRepository<GroupUser> GroupUserRepository => new GroupUserRepository(new MemoMapDbContext(Options));
    }
}
