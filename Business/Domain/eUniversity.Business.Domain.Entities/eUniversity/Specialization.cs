using System;
using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The Specialization entity
    /// </summary>
    public class Specialization : Entity, IHasCreation, IHasModificatoin
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
        /// Gets or sets the speciality.
        /// </summary>
        public virtual Speciality Speciality { get; set; }

        /// <summary>
        /// Gets or sets the speciality identifier.
        /// </summary>
        public long SpecialityId { get; set; }

        /// <summary>
        /// Gets or sets the сurricula.
        /// </summary>
        public virtual ICollection<Curriculum> Сurricula { get; set; }

        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; }

        #region IHasCreation Members

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        #endregion

        #region IHasModificatoin Members

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        #endregion
    }
}