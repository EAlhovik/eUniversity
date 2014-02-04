using System.Collections.Generic;
using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services
{
    public class ProfessorProfileService : BaseService<ProfessorProfile>, IProfessorProfileService
    {
        public ProfessorProfileService(IRepository<ProfessorProfile> repository)
            : base(repository)
        {
        }

        public IEnumerable<SelectedItemModel> GetProfessors(string term)
        {
            return Repository.All().Where(p => p.LastName.ToUpper().Contains(term.ToUpper())).Select(CreateSelectedItem);
        }

        protected override ProfessorProfile CreateItem()
        {
            throw new System.NotImplementedException();
        }

        protected override SelectedItemModel CreateSelectedItem(ProfessorProfile profile)
        {
            return new SelectedItemModel()
            {
                Id = profile.Id.ToString(),
                Text = profile.FirstName
            };
        }
    }
}