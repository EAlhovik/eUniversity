using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels;

namespace eUniversity.Web.Controllers
{
    public class LoockupController : Controller
    {
        private readonly ILoockupManagementService loockupService;

        public LoockupController(ILoockupManagementService loockupService)
        {
            this.loockupService = loockupService;
        }

        [HttpGet]
        public JsonResult GetProfessors(string term)
        {
            return Json(loockupService.GetProfessors(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet, AllowAnonymous]
        public JsonResult GetGroups(string term)
        {
            return Json(loockupService.GetGroups(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSubjects(string term)
        {
            var lst = new List<SelectedItemViewModel>()
            {
                new SelectedItemViewModel(){Id = "1", Text = "BD"},
                new SelectedItemViewModel(){Id = "2", Text = "Seti"},
                new SelectedItemViewModel(){Id = "2", Text = "Test"},
            };
            return Json(lst.Where(p => string.IsNullOrEmpty(term) || p.Text.ToUpper().Contains(term.ToUpper())), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSpecialities(string term)
        {
            return Json(loockupService.GetSpecialities(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSpeciality(string id)
        {
            long parseResult;
            if (long.TryParse(id, out parseResult))
            {
                return Json(loockupService.GetSpeciality(parseResult), JsonRequestBehavior.AllowGet);
            }
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
//            return Json(loockupService.GetSpecialities(id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSpecialization(string term)
        {
            return Json(loockupService.GetSpecialization(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSemesters(string term)
        {
            var semesters = loockupService.GetSemesters(term);
            return Json(semesters, JsonRequestBehavior.AllowGet);
        }
    }
}
