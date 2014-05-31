using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Enums;

namespace eUniversity.Web.Controllers
{
    public class ContentController : Controller
    {

        private readonly IMembershipManagementService membershipManagementService;

        public ContentController(IMembershipManagementService membershipManagementService)
        {
            this.membershipManagementService = membershipManagementService;
        }

        public ActionResult SideBar()
        {
            if (membershipManagementService.IsCurrentUserInRole(RoleEnum.Student))
            {
                return PartialView("StudentSideBar");
            }
            return PartialView();
        }
	}
}