using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents specialization service
    /// </summary>
    public class SpecializationService : BaseService<Specialization>, ISpecializationService
    {
        public SpecializationService(IRepository<Specialization> specializationRepository) : base(specializationRepository)
        {
        }

        protected override Specialization CreateItem()
        {
            return new Specialization();
        }

        protected override SelectedItemModel CreateSelectedItem(Specialization specialization)
        {
            return new SelectedItemModel
            {
                Id = specialization.Id.ToString(),
                Text = specialization.Name
            };
        }
    }
}