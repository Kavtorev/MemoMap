using MemoMap.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MemoMap.Domain.Services
{
    public class GroupPageService
    {
        public IUnitOfWork UnitOfWork { get; set; }
        public RegistrationFormValidation UsernameFieldValidator { get; set; }

        public GroupPageService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            UsernameFieldValidator = new RegistrationFormValidation();
        }

        public User GetGroupAdmin(int groupId)
        {
            return UnitOfWork.GroupRepository.FindGroupAdmin(groupId);
        }

        public string CheckUsernameValidity(string username)
        {
            UsernameFieldValidator.Properties["username"] = username;
            return UsernameFieldValidator.ValidateUsernameField();
        }

    }
}
