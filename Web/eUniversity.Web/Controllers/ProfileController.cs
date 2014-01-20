using System.Web.Mvc;
using eUniversity.Business.ViewModels.Profile;

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
            return View(new BasicProfileViewModel());
        }

        [HttpGet]
        public ActionResult BasicInfo()
        {
            return PartialView(@"EditorTemplates\BasicProfileViewModel", new BasicProfileViewModel());
            return View(@"EditorTemplates\BasicInfo");
        }

        [HttpPost]
        public ActionResult BasicInfo(BasicProfileViewModel viewModel)
        {
            return View(@"EditorTemplates\BasicInfo");
        }

        public ActionResult ChangePassword()
        {
            return PartialView(@"EditorTemplates\ChangePasswordViewModel", new ChangePasswordViewModel());
            return View(@"EditorTemplates\ChangePassword");
        }

        public ActionResult Settings()
        {
            return PartialView(@"EditorTemplates\SettingsViewModel", new SettingsViewModel());
        }
    }
}
