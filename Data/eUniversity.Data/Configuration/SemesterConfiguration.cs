using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class SemesterConfiguration : EntityTypeConfiguration<Semester>
    {
        public SemesterConfiguration()
        {
            HasRequired(s => s.Curriculum)
                .WithMany(c => c.Semesters)
                .HasForeignKey(s => s.CurriculaId);
        }
    }
}