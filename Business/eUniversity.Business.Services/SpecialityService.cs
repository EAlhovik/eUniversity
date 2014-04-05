using System;
using System.Linq.Expressions;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

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

        protected override SelectedItemModel CreateSelectedItem(Speciality item)
        {
            return new SelectedItemModel
            {
                Id = item.Id.ToString(),
                Text = item.Name
            };
        }

        protected override Expression<Func<Speciality, bool>> Predicate(string term)
        {
            return spec =>
                string.IsNullOrEmpty(term) || spec.Name.ToUpper().IndexOf(term.ToUpper()) >= 0;
        }
    }
}