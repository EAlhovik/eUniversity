using System;
using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The curricula entity
    /// </summary>
    public class Curriculum : Entity, IHasCreation, IHasModificatoin
    {
        public virtual ICollection<Semester> Semesters { get; set; }

        public virtual Specialization Specialization { get; set; }

        public long SpecializationId { get; set; }

        public DateTime DateOfEnactment { get; set; }

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