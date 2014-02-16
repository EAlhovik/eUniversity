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

        [HttpPost]
        public JsonResult Save(BasicProfileViewModel viewModel)
        {
            return Json(true);
        }

        public ActionResult Edit()
        {
            return View(new BasicProfileViewModel());
        }
    }
}