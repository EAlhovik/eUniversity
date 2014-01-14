using System.Web.Mvc;

namespace eUniversity.Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Student")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
