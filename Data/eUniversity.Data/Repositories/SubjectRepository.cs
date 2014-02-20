using System.Collections.Generic;
using System.Data.Entity;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Data.Contracts;

namespace eUniversity.Data.Repositories
{
    /// <summary>
    /// Represents subject repository
    /// </summary>
    public class SubjectRepository : EFRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(EUniversityDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return DbSet
                .Include(s => s.Semester.Curriculum);
        }
    }
}