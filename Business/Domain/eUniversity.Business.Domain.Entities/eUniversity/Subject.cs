using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Business.Domain.Entities.Enums;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The subject entity
    /// </summary>
    public class Subject : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Theme> Themes { get; set; }

        public virtual Semester Semester { get; set; }
        public long SemesterId { get; set; }

        public SubjectTypeEnum SubjectType { get; set; }
    }
}