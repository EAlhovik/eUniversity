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
            return View("StudentDashboard", GetDashboardViewModel());
            if (membershipManagementService.IsCurrentUserInRole(RoleEnum.Professor))
            {
                return View("StudentDashboard", dashboardManagementService.GetStudentDashboard());
            }
            return View("ProfessorDashboard", dashboardManagementService.GetProfessorDashboard());
        }

        private StudentDashboardViewModel GetDashboardViewModel()
        {
            return new StudentDashboardViewModel
            {
                Semesters = new List<SemesterViewModel>
                {
                    new SemesterViewModel
                    {
                        Sequential = 1,
                    },
                    new SemesterViewModel
                    {
                        Sequential = 2
                    },
                    new SemesterViewModel
                    {
                        Sequential = 3
                    },
                    new SemesterViewModel
                    {
                        Sequential = 4
                    },
                    new SemesterViewModel
                    {
                        Sequential = 5,
                        IsReadOnly = true
                    },
                    new SemesterViewModel
                    {
                        Sequential = 6,
                        IsReadOnly = true
                    },
                }
            };
        }
    }

    public class SemesterViewModel
    {
        public long Id { get; set; }
        public int Sequential { get; set; }
        public bool IsReadOnly { get; set; }

        public ICollection<SubjectViewModel> Subjects
        {
            get
            {
                return subjects ?? (subjects = new List<SubjectViewModel>());
            }
            set
            {
                subjects = value;
            }
        }

        #region private fields

        private ICollection<SubjectViewModel> subjects;

        #endregion
    }

    public class StudentDashboardViewModel
    {
        private IEnumerable<eUniversity.Web.Controllers.SemesterViewModel> semesters;

        public IEnumerable<SemesterViewModel> Semesters
        {
            get
            {
                return semesters ?? (semesters = Enumerable.Empty<SemesterViewModel>());
            }
            set
            {
                semesters = value;
            }
        }
    }
}