using System.Collections.Generic;
using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Dashboard;
using eUniversity.Business.ViewModels.Enums;
using eUniversity.Business.ViewModels.Theme;

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

        [HttpPost]
        public JsonResult ChooseTheme(long subjectId, ThemeRowViewModel theme)
        {
            return Json(true);
        }

        [HttpGet]
        public JsonResult GetSubjectThemes(long subjectId)
        {
            return Json(new List<ThemeRowViewModel>
            {
                new ThemeRowViewModel{Id = 1, Name = "1231", Description = "adasdasd"},
                new ThemeRowViewModel{Id = 2, Name = "qqqq", Description = "qqqqq"},
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSubjectDetail(long subjectId)
        {
            SubjectDetailViewModel detail = dashboardManagementService.GetSubjectDetail(subjectId);

            return Json(detail, JsonRequestBehavior.AllowGet);
        }
    }
}