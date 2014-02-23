using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Specialization;
using eUniversity.Web.Infrastructure.Controllers;

namespace eUniversity.Web.Controllers
{
    public class SpecializationController : BaseEntityModificationController<SpecializationRowViewModel>
    {
        public SpecializationController(ISpecializationManagementService specializationService)
            : base(specializationService)
        {
        }
    }
}