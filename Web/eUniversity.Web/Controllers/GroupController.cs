using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Group;
using eUniversity.Web.Infrastructure.Controllers;

namespace eUniversity.Web.Controllers
{
    public class GroupController : BaseEntityModificationController<GroupRowViewModel>
    {
        public GroupController(IGroupManagementService groupManagementService)
            : base(groupManagementService)
        {
        }
	}
}