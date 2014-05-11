using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The group entity
    /// </summary>
    public class Group : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long SpecializationId { get; set; }

        public virtual Specialization Specialization { get; set; }

        public virtual ICollection<StudentProfile> Students { get; set; }
    }
}