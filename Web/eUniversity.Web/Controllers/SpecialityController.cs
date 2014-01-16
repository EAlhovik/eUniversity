using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Helpers;
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
            var rows = specialityManagementService.GetSpecialities();
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

            return View();
        }

        public JsonResult GetSpecialities(string term)
        {
            var lst = new List<SelectedItemModel>()
                {
                    new SelectedItemModel() {Id= "user0", Text= "Disabled User"},
                    new SelectedItemModel() {Id= "user0", Text= "Jane Doe"},
                    new SelectedItemModel() {Id= "user0", Text= "Robert Paulson"},
                    new SelectedItemModel() {Id= "user0", Text= "Spongebob Squarepants"},
                    new SelectedItemModel() {Id= "user0", Text= "Planet Bob"},
                };
            if (string.IsNullOrEmpty(term))
            {

                return Json(lst, JsonRequestBehavior.AllowGet);
            }
            return Json(lst.Where(p => p.Text.ToUpper().Contains(term.ToUpper())), JsonRequestBehavior.AllowGet);
        }
    }
}
