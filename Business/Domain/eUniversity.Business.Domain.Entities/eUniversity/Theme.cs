using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The theme entity
    /// </summary>
    public class Theme : Entity
    {
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}