using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The semestr entity
    /// </summary>
    public class Semester : Entity
    {
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual Curriculum Curriculum { get; set; }
        public long? CurriculaId { get; set; }

        public int Sequential { get; set; }
    }
}