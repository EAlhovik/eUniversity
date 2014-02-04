using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents speciality service
    /// </summary>
    public class SpecialityService : BaseService<Speciality>, ISpecialityService
    {
        public SpecialityService(IRepository<Speciality> specialitySpecializationRepository, IAuthorizationService authorizationService)
            : base(specialitySpecializationRepository, authorizationService)
        {
        }

        #region ISpecialityService Members
        

        #endregion

        protected override Speciality CreateItem()
        {
            return new Speciality();
        }

        protected override SelectedItemModel CreateSelectedItem(Speciality item)
        {
            throw new System.NotImplementedException();
        }

        private void UpdateHistoryInformation(Speciality speciality)
        {
        }
    }
}