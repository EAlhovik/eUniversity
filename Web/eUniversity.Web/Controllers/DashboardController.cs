using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Business.ViewModels.Enums;

namespace eUniversity.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardManagementService dashboardManagementService;
        private readonly IMembershipManagementService membershipManagementService;

        public DashboardController(IDashboardManagementService dashboardManagementService, IMembershipManagementService membershipManagementService)
        {
            this.dashboardManagementService = dashboardManagementService;
            this.membershipManagementService = membershipManagementService;
        }

        public ActionResult Index()
        {
            dashboardManagementService.GetStudentDashboard();
            if (membershipManagementService.IsCurrentUserInRole(RoleEnum.Student))
            {
                return View("StudentDashboard", dashboardManagementService.GetStudentDashboard());
            }
            return View("ProfessorDashboard", dashboardManagementService.GetProfessorDashboard());
        }
    }
}