using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Data.Contracts;

namespace eUniversity.Data.Repositories
{
    /// <summary>
    /// Represents subject repository
    /// </summary>
    public class SubjectRepository : EFRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(EUniversityDbContext dbContext)
            : base(dbContext)
        {
        }

        public override Subject GetById(long id)
        {
            return All()
                .Include(s => s.Themes)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return DbSet
                .Include(s => s.Semester.Curriculum)
                ;
        }
//
//        public Subject GetSubjectById(long id)
//        {
//            return All()
//                .Include(s => s.Themes)
//                .FirstOrDefault(s => s.Id == id);
//        }
    }
}