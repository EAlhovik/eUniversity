using System;
using eUniversity.Business.ViewModels.Base;
using eUniversity.Business.ViewModels.Enums;

namespace eUniversity.Business.ViewModels.Specialization
{
    /// <summary>
    /// View model for specialization row
    /// </summary>
    public class SpecializationRowViewModel : IViewModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the speciality identifier.
        /// </summary>
        public string SpecialityId { get; set; }

        public EntityStatusEnum Status { get; set; }

        public string LastModified { get; set; }
    }
}