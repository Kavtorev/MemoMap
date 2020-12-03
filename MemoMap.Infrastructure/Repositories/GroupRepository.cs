
using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoMap.Infrastructure.Repositories
{
    public class GroupRepository: Repository<Group>, IGroupRepository
    {
        public GroupRepository(MemoMapDbContext db):base(db)
        {
            
        }
    }
}
