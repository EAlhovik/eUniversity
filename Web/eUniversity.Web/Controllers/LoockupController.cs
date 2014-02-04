using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Helpers;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Common.Utilities;

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

        [HttpGet]
        public JsonResult GetSubjects(string term)
        {
            var lst = new List<SelectedItemModel>()
            {
                new SelectedItemModel(){Id = "1", Text = "BD"},
                new SelectedItemModel(){Id = "2", Text = "Seti"},
                new SelectedItemModel(){Id = "2", Text = "Test"},
            };
            return Json(lst.Where(p => string.IsNullOrEmpty(term) || p.Text.ToUpper().Contains(term.ToUpper())), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSpecialities(string term)
        {
            return Json(loockupService.GetSpecialities(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSpecialization(string term)
        {
            return Json(loockupService.GetSpecialization(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSemesters(string term)
        {
            var values = EnumHelper.GetEnumValues(typeof(SemesterEnum)).Select(p => new SelectedItemModel { Id = p.Key, Text = p.Value });
            if (string.IsNullOrEmpty(term))
            {
                return Json(values, JsonRequestBehavior.AllowGet);
            }
            return Json(values.Where(s => s.Text.Contains(term)), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSpeciality(long? id)// TODo: remove after knockout specialization page
        {
            return Json(loockupService.GetSpeciality(id), JsonRequestBehavior.AllowGet);
        }
    }
}
