using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The theme entity
    /// </summary>
    public class Theme : Entity
    {
        public virtual Subject Subject { get; set; }
        public long SubjectId { get; set; }
    }
}