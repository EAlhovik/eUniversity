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
    /// Represents specialization service
    /// </summary>
    public class SpecializationService : BaseService<Specialization>, ISpecializationService
    {
        public SpecializationService(IRepository<Specialization> specializationRepository, IAuthorizationService authorizationService)
            : base(specializationRepository, authorizationService)
        {
        }

        protected override SelectedItemModel CreateSelectedItem(Specialization specialization)
        {
            return new SelectedItemModel
            {
                Id = specialization.Id.ToString(),
                Text = specialization.Name
            };
        }

        protected override Expression<Func<Specialization, bool>> Predicate(string term)
        {
            return spec => spec.SpecialityId.HasValue &&
                (string.IsNullOrEmpty(term) || spec.Name.ToUpper().IndexOf(term.ToUpper()) >= 0);
        }

        protected override bool HasAllRequired(Specialization entity)
        {
            return entity.SpecialityId.HasValue && !string.IsNullOrEmpty(entity.Name);
        }
    }
}