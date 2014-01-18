using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class StudentProfileConfiguration : EntityTypeConfiguration<StudentProfile>
    {
        public StudentProfileConfiguration()
        {
            ToTable("StudentProfile");
        }
    }
}