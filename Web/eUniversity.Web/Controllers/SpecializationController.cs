using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Specialization;

namespace eUniversity.Web.Controllers
{
    public class SpecializationController : Controller
    {
        private readonly ISpecializationManagementService specializationService;

        public SpecializationController(ISpecializationManagementService specializationService)
        {
            this.specializationService = specializationService;
        }

        public ActionResult Index()
        {
            var rows = specializationService.GetSpecializations();
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
            return View(viewModel);
        }
    }
}