using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Speciality;
using eUniversity.Web.Infrastructure.Controllers;

namespace eUniversity.Web.Controllers
{
    public class SpecialityController : BaseEntityModificationController<SpecialityViewModel, SpecialityRowViewModel>
    {
        private readonly ISpecialityManagementService specialityManagementService;
        public SpecialityController(ISpecialityManagementService specialityManagementService)
            : base(specialityManagementService)
        {
            this.specialityManagementService = specialityManagementService;
        }
    }
}
