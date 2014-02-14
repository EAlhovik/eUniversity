using System.Web.Mvc;
using eUniversity.Business.ViewModels.Profile;

namespace eUniversity.Web.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Index()
        {
            return View(new ProfileViewModel
            {
                BasicProfile = new BasicProfileViewModel()
                {
                    GeneralSection = new GeneralInfoSectionViewModel()
                    {
                        FirstName = "dasd",
                        Comment = "asdasdasda"
                    },
                },
                Settings = new SettingsViewModel() { },
                ChangePassword = new ChangePasswordViewModel() { }
            });
        }

        public ActionResult Edit()
        {
            return View(new BasicProfileViewModel());
        }

        [HttpGet]
        public ActionResult BasicInfo()
        {
            return PartialView(@"EditorTemplates\BasicProfileViewModel", new BasicProfileViewModel());
        }

        [HttpPost]
        public ActionResult BasicInfo(BasicProfileViewModel viewModel)
        {
            return View(@"EditorTemplates\BasicInfo");
        }

        public ActionResult ChangePassword()
        {
            return PartialView(@"EditorTemplates\ChangePasswordViewModel", new ChangePasswordViewModel());
        }

        public ActionResult Settings()
        {
            return PartialView(@"EditorTemplates\SettingsViewModel", new SettingsViewModel());
        }
    }
}
