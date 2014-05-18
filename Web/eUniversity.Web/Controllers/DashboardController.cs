using System.Collections.Generic;
using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels;
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
        public JsonResult UnsubscribeFromTheme(long subjectId, long themeId)
        {
            dashboardManagementService.UnsubscribeFromTheme(subjectId, themeId);
            return Json(true);
        }

        [HttpPost]
        public JsonResult ChooseTheme(long subjectId, ThemeRowViewModel theme)
        {
            var result = new AjaxViewModel();
            var isThemeAvailable = dashboardManagementService.IsThemeAvailable(subjectId, theme.Id);
            if (string.IsNullOrEmpty(isThemeAvailable))
            {
                result.Data = dashboardManagementService.ChooseTheme(subjectId, theme);
            }
            else
            {
                result.Errors.Add(isThemeAvailable);
            }
            return Json(result);
        }

        [HttpGet]
        public JsonResult GetSubjectThemes(long subjectId)
        {
            var themes = dashboardManagementService.GetSubjectThemes(subjectId);
            return Json(themes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSubjectDetail(long subjectId)
        {
            SubjectDetailViewModel detail = dashboardManagementService.GetSubjectDetail(subjectId);

            return Json(detail, JsonRequestBehavior.AllowGet);
        }
    }
}