using System;
using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents curriculum service
    /// </summary>
    public class CurriculumService : BaseService<Curriculum>, ICurriculumService
    {
        public CurriculumService(ICurriculumRepository repository)
            : base(repository)
        {
        }

        public Curriculum GetCurriculumForStudent(long specializationId, DateTime dateOfAdmission)
        {
            var curriculum = Repository.All()
                .FirstOrDefault(curr =>
                        curr.DateOfEnactment.Year.Equals(dateOfAdmission.Year) &&
                        curr.SpecializationId == specializationId);
            return curriculum == null ? null : Repository.GetById(curriculum.Id);
        }

        public new Curriculum CreateOrOpen(long? id)
        {
            if (id == null || id.Value == 0)
            {
                return CreateItem();
            }
            var item = Repository.GetById(id.Value);
            return item ?? CreateItem();
        }

        protected override Curriculum CreateItem()
        {
            return new Curriculum
            {
                Semesters = Enumerable.Range(1, 8)
                                .Select(p => new Semester() { Sequential = p })
                                .ToList(),
                DateOfEnactment = DateTime.Today
            };
        }

        protected override SelectedItemModel CreateSelectedItem(Curriculum item)
        {
            throw new NotImplementedException();
        }
    }
}