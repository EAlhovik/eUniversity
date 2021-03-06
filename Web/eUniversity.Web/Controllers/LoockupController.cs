﻿using System.Linq;
using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;

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
        public JsonResult GetSemesters(string term)
        {
            var semesters = loockupService.GetSemesters(term);
            return Json(semesters, JsonRequestBehavior.AllowGet);
        }

        #region Subject

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
        public JsonResult GetSubjectType(string id)
        {
            var subject = loockupService.GetSubjectType(id);

            return Json((object)subject ?? string.Empty, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetSubjectTypes(bool isLast = false)
        {
            return Json(loockupService.GetSubjectTypes(isLast), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Speciality

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

        #endregion

        #region Specialization

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

        #endregion

        #region Theme

        [HttpGet]
        public JsonResult GetThemes(string term)
        {
            return Json(loockupService.GetThemes(term), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetTheme(string id)
        {
            var theme = loockupService.GetTheme(id);

            return Json((object)theme ?? string.Empty, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetThemeDescription(long id)
        {
            string description = loockupService.GetThemeDescription(id);
            return Json(description, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
