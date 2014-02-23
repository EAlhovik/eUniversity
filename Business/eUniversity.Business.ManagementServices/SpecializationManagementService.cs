using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ManagementServices.Base;
using eUniversity.Business.ViewModels.Specialization;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices
{
    /// <summary>
    /// Represents specialization management service
    /// </summary>
    public class SpecializationManagementService : BaseManagementService<SpecializationRowViewModel, Specialization>, ISpecializationManagementService
    {
        public SpecializationManagementService(IEUniversityUow unitOfWork, IBaseService<Specialization> service) : base(unitOfWork, service)
        {
        }
    }
}