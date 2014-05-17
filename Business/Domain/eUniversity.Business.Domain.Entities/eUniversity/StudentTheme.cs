using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The student theme entity
    /// </summary>
    public class StudentTheme : Entity
    {
        public virtual StudentProfile Student { get; set; }
        public long StudentId { get; set; }
        public virtual Theme Theme { get; set; }
        public long ThemeId { get; set; }
    }
}