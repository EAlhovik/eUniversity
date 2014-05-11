using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class StudentProfileConfiguration : EntityTypeConfiguration<StudentProfile>
    {
        public StudentProfileConfiguration()
        {
            HasRequired(student => student.Group)
                .WithMany(group => group.Students)
                .HasForeignKey(student => student.GroupId);

            ToTable("StudentProfile");
        }
    }
}