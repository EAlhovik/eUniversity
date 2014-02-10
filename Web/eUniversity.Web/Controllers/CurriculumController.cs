using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Web.Infrastructure.Controllers;

namespace eUniversity.Web.Controllers
{
    public class CurriculumController : BaseEntityModificationController<CurriculumViewModel, CurriculumRowViewModel>
    {
//        private readonly ICurriculumManagementService curriculumManagementService;

        public CurriculumController(ICurriculumManagementService curriculumManagementService)
            : base(curriculumManagementService)
        {
//            this.curriculumManagementService = curriculumManagementService;
        }
/*
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long? curriculumId)
        {
            var curriculum = curriculumManagementService.Open(curriculumId);
            return View(curriculum);
        }

        [HttpPost]
        public ActionResult Edit(CurriculumViewModel curriculum)
        {
            curriculumManagementService.Save(curriculum);
            return Json(curriculum);
        }*/
    }
}
