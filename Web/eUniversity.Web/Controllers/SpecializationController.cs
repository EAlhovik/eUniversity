using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Specialization;
using eUniversity.Web.Infrastructure.Controllers;

namespace eUniversity.Web.Controllers
{
    public class SpecializationController : BaseEntityModificationController<SpecializationViewModel, SpecializationRowViewModel>
    {
        public SpecializationController(ISpecializationManagementService specializationService)
            : base(specializationService)
        {
        }
    }
   /* public class SpecializationController : Controller
    {
        private readonly ISpecializationManagementService specializationService;
        public SpecializationController(ISpecializationManagementService specializationService)
        {
            this.specializationService = specializationService;
        }

        public ActionResult Index()
        {
            var rows = specializationService.GetRows();
            return View(rows);
        }

        [HttpGet]
        public ActionResult Edit(long? specializationId)
        {
            var viewModel = specializationService.Open(specializationId);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(SpecializationViewModel viewModel)
        {
            specializationService.Save(viewModel);
            return RedirectToAction("Index");
        }
    }*/
}