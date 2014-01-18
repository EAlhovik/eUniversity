using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class ProfessorProfileConfiguration : EntityTypeConfiguration<ProfessorProfile>
    {
        public ProfessorProfileConfiguration()
        {
            ToTable("ProfessorProfile");
        }
    }
}