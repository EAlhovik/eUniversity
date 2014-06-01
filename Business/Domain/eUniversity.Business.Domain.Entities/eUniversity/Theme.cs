using System;
using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The theme entity
    /// </summary>
    public class Theme : Entity, IHasCreation, IHasModificatoin
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

        public virtual ICollection<StudentTheme> Students { get; set; }

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