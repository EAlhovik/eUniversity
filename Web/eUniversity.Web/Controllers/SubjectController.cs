using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels;

namespace eUniversity.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectManagementService subjectManagementService;

        public SubjectController(ISubjectManagementService subjectManagementService)
        {
            this.subjectManagementService = subjectManagementService;
        }

        public ActionResult Index()
        {
            var grid = new GridViewModel
            {
                Rows = subjectManagementService.GetRows()
            };
            return View(grid);
        }

    }
}
