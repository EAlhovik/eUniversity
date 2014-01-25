using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Helpers;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Common.Utilities;
using Microsoft.Ajax.Utilities;

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
        public JsonResult GetSpecialities(string term)
        {
            return Json(loockupService.GetSpecialities(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSpeciality(long? id)// TODo_: remove after knockout specialization page
        {
            return Json(loockupService.GetSpeciality(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSemesters(string term)
        {
            var values = EnumHelper.GetEnumValues(typeof(SemesterEnum)).Select(p => new SelectedItemModel { Id = p.Key, Text = p.Value });
            if (string.IsNullOrEmpty(term))
            {
                return Json(values, JsonRequestBehavior.AllowGet);
            }
            return Json(values.Where(s => s.Text.Contains(term)), JsonRequestBehavior.AllowGet);
        }
    }
}
