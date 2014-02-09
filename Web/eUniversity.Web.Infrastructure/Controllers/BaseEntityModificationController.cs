using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Base;

namespace eUniversity.Web.Infrastructure.Controllers
{
    public class BaseEntityModificationController<TViewModel, TRowViewModel> : Controller
        where TViewModel : class, IViewModel
        where TRowViewModel : class
    {
        protected readonly IBaseManagementService<TViewModel, TRowViewModel> ManagementService;

        public BaseEntityModificationController(IBaseManagementService<TViewModel, TRowViewModel> managementService)
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

        [HttpGet]
        public ActionResult Edit(long? id)
        {
            var viewModel = ManagementService.Open(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(TViewModel viewModel)
        {
            ManagementService.Save(viewModel);

            return RedirectToAction("Index");
        }
    }
}