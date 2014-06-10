using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            HasOptional(group => group.Specialization)
                .WithMany(specialization => specialization.Groups)
                .HasForeignKey(group => group.SpecializationId);
        } 
    }
}