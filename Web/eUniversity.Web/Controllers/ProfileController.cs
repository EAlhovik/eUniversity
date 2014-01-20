using System.Web.Mvc;

namespace eUniversity.Web.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult BasicInfo()
        {
            return View(@"EditorTemplates\BasicInfo");
        }

        public ActionResult ChangePassword()
        {
            return View(@"EditorTemplates\ChangePassword");
        }

        public ActionResult Settings()
        {
            return View(@"EditorTemplates\Settings");
        }
    }
}
