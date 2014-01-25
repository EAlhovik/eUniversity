using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Data;

namespace eUniversity.Web.Controllers
{
    public class CurriculumController : Controller
    {
        private readonly ICurriculumManagementService curСurriculumManagementService;

        public CurriculumController(ICurriculumManagementService curСurriculumManagementService)
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
            curriculum.HeaderSection.SpecializationId = 1;
            return View(curriculum);
        }
    }
}
