using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;

namespace eUniversity.Web.Controllers
{
    public class MembershipController : Controller
    {
        private readonly IMembershipManagementService membershipManagementService;

        public MembershipController(IMembershipManagementService membershipManagementService)
        {
            this.membershipManagementService = membershipManagementService;
        }

        public ActionResult Index()
        {
            var t = membershipManagementService.GetUsers();
            return View(t);
        }
	}
}