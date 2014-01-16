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
        public JsonResult GetSpecialities(string term)
        {
            return Json(loockupService.GetSpecialities(term),JsonRequestBehavior.AllowGet );
        }
    }
}
