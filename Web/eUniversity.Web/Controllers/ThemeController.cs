using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Theme;
using eUniversity.Web.Infrastructure.Controllers;

namespace eUniversity.Web.Controllers
{
    public class ThemeController : BaseEntityModificationController<ThemeRowViewModel>
    {
        public ThemeController(IThemeManagementService managementService) : 
            base(managementService)
        {
        }
	}
}