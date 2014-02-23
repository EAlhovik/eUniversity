using System.Collections.Generic;
using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Base;

namespace eUniversity.Web.Infrastructure.Controllers
{
    public class BaseEntityModificationController<TRowViewModel> : Controller
        where TRowViewModel : class, IViewModel
    {
        protected readonly IBaseManagementService<TRowViewModel> ManagementService;

        public BaseEntityModificationController(IBaseManagementService<TRowViewModel> managementService)
        {
            ManagementService = managementService;
        }

        public ActionResult Index()
        {
          var grid = new GridViewModel
            {
                Rows = ManagementService.GetRows()
            };
            return View(grid);
        }

        [HttpPost]
        public JsonResult Save(IEnumerable<TRowViewModel> viewModels)
        {
            ManagementService.Save(viewModels);
            return Json(new AjaxViewModel()
            {
                Data = viewModels
            });
        }

        [HttpPost]
        public ActionResult Remove(IEnumerable<TRowViewModel> viewModels)
        {
            ManagementService.Remove(viewModels);
            return Json(new AjaxViewModel()
            {
                Data = viewModels
            });
        }
    }
}