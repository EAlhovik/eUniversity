using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents curriculum service
    /// </summary>
    public class CurriculumService : BaseService<Сurriculum>, ICurriculumService
    {
        public CurriculumService(IRepository<Сurriculum> repository) : base(repository)
        {
        }

        protected override Сurriculum CreateItem()
        {
            return new Сurriculum();
        }
    }
}