using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ManagementServices.Base;
using eUniversity.Business.ViewModels.Speciality;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices
{
    /// <summary>
    /// Represents speciality managements service
    /// </summary>
    public class SpecialityManagementService : BaseManagementService<SpecialityViewModel, SpecialityRowViewModel, Speciality>, ISpecialityManagementService
    {
        public SpecialityManagementService(IEUniversityUow unitOfWork, IBaseService<Speciality> service) : base(unitOfWork, service)
        {
        }
    }
}