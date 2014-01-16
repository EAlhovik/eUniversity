using System.Collections.Generic;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents speciality service
    /// </summary>
    public class SpecialityService : BaseService<Speciality>, ISpecialityService
    {
        public SpecialityService(IRepository<Speciality> specialitySpecializationRepository):base(specialitySpecializationRepository)
        {
        }

        #region ISpecialityService Members
        

        #endregion

        protected override Speciality CreateItem()
        {
            return new Speciality();
        }

        private Speciality CreateSpeciality()
        {
            return new Speciality();
        }

        private void UpdateHistoryInformation(Speciality speciality)
        {
        }
    }
}