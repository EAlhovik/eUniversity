using System.Data.Entity.ModelConfiguration;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data.Configuration
{
    public class StudentThemeConfiguration : EntityTypeConfiguration<StudentTheme>
    {
        public StudentThemeConfiguration()
        {
            HasRequired(studentTheme => studentTheme.Student)
                .WithMany(student => student.Themes)
                .HasForeignKey(studentTheme => studentTheme.StudentId);

            HasRequired(studentTheme => studentTheme.Theme)
                .WithMany(theme => theme.Students)
                .HasForeignKey(studentTheme => studentTheme.ThemeId);
        }
    }
}