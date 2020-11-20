using MemoMap.Domain;
using MemoMap.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(MemoMapDbContext db) : base(db)
        {

        }
    }
}
