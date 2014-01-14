using System.Web.Mvc;

namespace eUniversity.Web.Controllers
{
    public class SpecialityController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAjaxRequest())
            {
                System.Threading.Thread.Sleep(1000);
                return PartialView("Index");
            }
            return View();
        }

        public ActionResult New()
        {
            if (Request.IsAjaxRequest())
            {
                System.Threading.Thread.Sleep(1000);
                return PartialView("New");
            }
            return View();
        }
    }
}
