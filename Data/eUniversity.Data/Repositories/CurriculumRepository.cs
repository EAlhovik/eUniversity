using System.Data.Entity;
using System.Linq;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Data.Contracts;

namespace eUniversity.Data.Repositories
{
    /// <summary>
    /// Represents curriculum repository
    /// </summary>
    public class CurriculumRepository : EFRepository<Curriculum>, ICurriculumRepository
    {
        public CurriculumRepository(EUniversityDbContext dbContext)
            : base(dbContext)
        {
        }

        public override Curriculum GetById(long id)
        {
            return DbSet
                .Include(c => c.Semesters
                    .Select(s => s.Subjects))
                .FirstOrDefault(c => c.Id == id);
        }
    }
}