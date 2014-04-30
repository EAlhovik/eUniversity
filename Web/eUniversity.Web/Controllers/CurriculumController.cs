using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Web.Infrastructure.Controllers;

namespace eUniversity.Web.Controllers
{
    public class CurriculumController : BaseEntityModificationController<CurriculumRowViewModel>
    {
        private ICurriculumManagementService CurriculumManagementService
        {
            get { return (ICurriculumManagementService)ManagementService; }
        }
        public CurriculumController(ICurriculumManagementService curriculumManagementService)
            : base(curriculumManagementService)
        {
        }

        [HttpGet]
        public ActionResult Edit(long? id)
        {
            var viewModel = CurriculumManagementService.Open(id);
            return View(viewModel);
        }

        [HttpPost]
        public JsonResult Edit(CurriculumViewModel viewModel)
        {
            CurriculumManagementService.Save(viewModel);

            return Json(true);
        }

        [HttpPost]
        public JsonResult NewCountSemesters(SelectedItemViewModel viewModel)
        {
            CurriculumViewModel curriculum = CurriculumManagementService.CreateCurriculum(viewModel);
            var result = new AjaxViewModel
            {
                Data = curriculum
            };
            return Json(result);
        }
    }
}
