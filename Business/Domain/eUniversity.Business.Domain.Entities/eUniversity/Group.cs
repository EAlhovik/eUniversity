using System;
using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Business.Domain.Entities.Enums;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The group entity
    /// </summary>
    public class Group : Entity, IHasCreation, IHasModificatoin, IHasStatusTracker
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long? SpecializationId { get; set; }

        public DateTime DateOfAdmission { get; set; }

        public virtual Specialization Specialization { get; set; }

        public virtual ICollection<StudentProfile> Students { get; set; }

        #region IHasCreation Members

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        #endregion

        #region IHasModificatoin Members

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        #endregion

        #region IHasStatusTracker Members

        public EntityStatusEnum Status { get; set; }

        #endregion
    }
}