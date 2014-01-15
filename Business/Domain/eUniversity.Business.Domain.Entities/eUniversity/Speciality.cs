using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The Speciality entity
    /// </summary>
    public class Speciality : Entity//, IEntityCreated, IEntityChanged
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the specializations.
        /// </summary>
        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}