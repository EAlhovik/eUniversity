using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ManagementServices.Base;
using eUniversity.Business.ViewModels.Group;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices
{
    public class GroupManagementService :  BaseManagementService<GroupRowViewModel, Group>, IGroupManagementService
    {
        public GroupManagementService(IEUniversityUow unitOfWork, IGroupService service) : base(unitOfWork, service)
        {
        }
    }
}