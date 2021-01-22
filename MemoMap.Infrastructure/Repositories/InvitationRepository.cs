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

        public async Task<List<Invitation>> FindAllReceivedInvites(int userId)
        {
            return await _dbContext.Invitations
                .Where(p => p.InvitedId == userId)
                .Select(p => new Invitation {
                    Id = p.Id,
                    InvitedId = p.InvitedId,
                    Inviting = p.Inviting, 
                    GroupId = p.GroupId, 
                    Group = p.Group 
                })
                .ToListAsync();
        }

        public int FindTheNumberOfReceivedInvites(int userId)
        {
            return _dbContext.Invitations.Count(p => p.InvitedId == userId);
        }

        public async Task<Invitation> FindByInvitedGroupId(int invitedId, int groupId)
        {
            return await _dbContext.Invitations
                .Where(p => p.InvitedId == invitedId && p.GroupId == groupId)
                .SingleOrDefaultAsync();
        }
    }
}
