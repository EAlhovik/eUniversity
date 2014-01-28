﻿using System.Web.Mvc;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Web.Controllers
{
    public class CurriculumController : Controller
    {
        private readonly ICurriculumManagementService curriculumManagementService;

        public CurriculumController(ICurriculumManagementService curriculumManagementService)
        {
            this.curriculumManagementService = curriculumManagementService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(long? curriculumId)
        {
            var curriculum = curriculumManagementService.Open(curriculumId);
            return View(curriculum);
        }

        [HttpPost]
        public ActionResult Edit(CurriculumViewModel curriculum)
        {
            curriculumManagementService.Save(curriculum);
            return Json(curriculum);
        }
    }
}