using System;
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
            return Json(loockupService.GetSubjects(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSubject(string id)
        {
            var subject = loockupService.GetSubject(id);

            return Json((object)subject ?? string.Empty, JsonRequestBehavior.AllowGet);
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
        }

        [HttpGet]
        public JsonResult GetSpecialization(string id)
        {
            long parseResult;
            if (long.TryParse(id, out parseResult))
            {
                return Json(loockupService.GetSpecialization(parseResult), JsonRequestBehavior.AllowGet);
            }
            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSpecializations(string term)
        {
            return Json(loockupService.GetSpecializations(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSemesters(string term)
        {
            var semesters = loockupService.GetSemesters(term);
            return Json(semesters, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSubjectTypes()
        {
            return Json(loockupService.GetSubjectTypes().Select(p => new { value = p.Id, text = p.Text }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetThemes(string term)
        {
            return Json(loockupService.GetSpecialities(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTheme(IEnumerable<string> ids)
        {
            return Json(loockupService.GetSpecialities(""), JsonRequestBehavior.AllowGet);
        }
    }
}
