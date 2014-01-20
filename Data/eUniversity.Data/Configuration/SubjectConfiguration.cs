using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration()
        {
            HasRequired(subject => subject.Semester)
                .WithMany(semestr => semestr.Subjects)
                .HasForeignKey(subject => subject.SemesterId);
        }
    }
}