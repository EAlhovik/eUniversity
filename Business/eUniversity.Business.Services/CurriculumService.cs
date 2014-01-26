using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;

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

        protected override Curriculum CreateItem()
        {
            return new Curriculum
            {
                Semesters = Enumerable.Range(1, 8)
                                .Select(p => new Semester() { Sequential = p })
                                .ToList()
            };
        }
    }
}