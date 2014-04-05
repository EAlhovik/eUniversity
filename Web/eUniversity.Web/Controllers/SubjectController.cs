using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Subject;

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

        [HttpGet]
        public JsonResult GetSubjectRow(long id)
        {
            var viewModel = subjectManagementService.GetSubjectRowById(id);
            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveSubject(SubjectRowViewModel viewModel)
        {
            subjectManagementService.SaveSubject(viewModel);
//            var selectedSubject = subjectManagementService.GetSubjectRowById(1);
//            return Json(selectedSubject);
            return Json(viewModel);
        }
    }
}