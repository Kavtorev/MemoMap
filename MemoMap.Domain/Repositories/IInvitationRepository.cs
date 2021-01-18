using MemoMap.Domain.Models;
using MemoMap.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Domain.Repositories
{
    public interface IInvitationRepository : IRepository<Invitation>
    {
        Task<Invitation> FindByInvitedGroupId(int invitedId, int groupId);
    }
}
