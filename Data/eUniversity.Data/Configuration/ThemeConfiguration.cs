using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class ThemeConfiguration : EntityTypeConfiguration<Theme>
    {
        public ThemeConfiguration()
        {
         /*   HasRequired(theme => theme.Subject)
                .WithMany(subject => subject.Themes)
//                .HasForeignKey(theme => theme.SubjectId)
                ;
            */
        }
    }
}