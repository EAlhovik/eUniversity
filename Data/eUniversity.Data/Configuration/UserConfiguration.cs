using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);
//            this.HasOptional(user => user.Profile).WithMany().HasForeignKey(p => p.PersonId);
            this.HasOptional(user => user.Profile).WithRequired(person => person.User);

            // Properties
            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(256);

            // Table & Column Mappings
            this.ToTable("Users");
        }
    }
}