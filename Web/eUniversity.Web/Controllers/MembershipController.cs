using System.Collections.Generic;
using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Membership;

namespace eUniversity.Web.Controllers
{
    [Authorize(Roles = "Professor, Admin")]
    public class MembershipController : Controller
    {
        private readonly IMembershipManagementService membershipManagementService;

        public MembershipController(IMembershipManagementService membershipManagementService)
        {
            this.membershipManagementService = membershipManagementService;
        }

        public ActionResult Index()
        {
            var viewModel = new MembershipViewModel
            {
                Users = membershipManagementService.GetUsers()
            };
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult ActivateUser(IEnumerable<long> userIds)
        {
            membershipManagementService.ApproveUsers(userIds);
            return Json(userIds);
        }
	}
}