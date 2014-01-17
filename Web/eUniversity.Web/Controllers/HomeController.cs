using System.Web.Mvc;

namespace eUniversity.Web.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = "Student, Professor")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
