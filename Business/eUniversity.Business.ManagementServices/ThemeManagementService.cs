using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ManagementServices.Base;
using eUniversity.Business.ViewModels.Theme;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices
{
    /// <summary>
    /// Represents theme managements service
    /// </summary>
    public class ThemeManagementService : BaseManagementService<ThemeRowViewModel, Theme>, IThemeManagementService
    {
        public ThemeManagementService(IEUniversityUow unitOfWork, IBaseService<Theme> service)
            : base(unitOfWork, service)
        {
        }
    }
}