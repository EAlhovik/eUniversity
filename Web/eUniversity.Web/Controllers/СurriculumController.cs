using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;

namespace eUniversity.Web.Controllers
{
    public class СurriculumController : Controller
    {
        private readonly IСurriculumManagementService curСurriculumManagementService;

        public СurriculumController(IСurriculumManagementService curСurriculumManagementService)
        {
            this.curСurriculumManagementService = curСurriculumManagementService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(long? curriculumId)
        {
            var curriculum = curСurriculumManagementService.Open(curriculumId);
            return View();
        }
    }
}
