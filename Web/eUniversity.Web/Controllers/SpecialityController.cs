using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Speciality;

namespace eUniversity.Web.Controllers
{
    public class SpecialityController : Controller
    {
        private readonly ISpecialityManagementService specialityManagementService;

        public SpecialityController(ISpecialityManagementService specialityManagementService)
        {
            this.specialityManagementService = specialityManagementService;
        }

        public ActionResult Index()
        {
            var rows = specialityManagementService.GetRows();
            return View(rows);
        }

        [HttpGet]
        public ActionResult Edit(long? specialityId)
        {
            var speciality = specialityManagementService.Open(specialityId);

            return View(speciality);
        }

        [HttpPost]
        public ActionResult Edit(SpecialityViewModel speciality)
        {
            specialityManagementService.Save(speciality);

            return RedirectToAction("Index");
        }
    }
}
