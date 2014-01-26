using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class CurriculumConfiguration : EntityTypeConfiguration<Curriculum>
    {
        public CurriculumConfiguration()
        {
            HasRequired(c => c.Specialization)
                .WithMany(s => s.Сurricula)
                .HasForeignKey(c => c.SpecializationId);
        }
    }
}