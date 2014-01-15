using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class SpecializationConfiguration : EntityTypeConfiguration<Specialization>
    {
        public SpecializationConfiguration()
        {
            HasRequired(specialization => specialization.Speciality)
                .WithMany(speciality => speciality.Specializations)
                .HasForeignKey(specialization => specialization.SpecialityId);
        }
    }
}