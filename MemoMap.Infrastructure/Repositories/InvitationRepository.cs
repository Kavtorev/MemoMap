using MemoMap.Domain.Models;
using MemoMap.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Infrastructure.Repositories
{
    public class InvitationRepository : Repository<Invitation>, IInvitationRepository
    {
        public InvitationRepository(MemoMapDbContext db) : base(db)
        {

        }

        public async Task<Invitation> FindByInvitedGroupId(int invitedId, int groupId)
        {
            return await _dbContext.Invitations
                .Where(p => p.InvitedId == invitedId && p.GroupId == groupId)
                .SingleOrDefaultAsync();
        }
    }
}
