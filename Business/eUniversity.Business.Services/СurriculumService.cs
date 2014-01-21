using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents curriculum service
    /// </summary>
    public class СurriculumService : BaseService<Сurriculum>, IСurriculumService
    {
        public СurriculumService(IRepository<Сurriculum> repository) : base(repository)
        {
        }

        protected override Сurriculum CreateItem()
        {
            return new Сurriculum();
        }
    }
}