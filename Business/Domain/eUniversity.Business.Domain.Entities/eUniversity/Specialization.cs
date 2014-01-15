﻿using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The Specialization entity
    /// </summary>
    public class Specialization : Entity
    {
        /// <summary>
        /// Gets or sets the speciality.
        /// </summary>
        public virtual Speciality Speciality { get; set; }

        /// <summary>
        /// Gets or sets the speciality identifier.
        /// </summary>
        public long SpecialityId { get; set; }
    }
}