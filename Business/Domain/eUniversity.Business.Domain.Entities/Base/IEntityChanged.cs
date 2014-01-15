using System;

namespace eUniversity.Business.Domain.Entities.Base
{
    /// <summary>
    /// Interface for entities with history
    /// </summary>
    public interface IEntityChanged : IEntity
    {
        /// <summary>
        /// Gets or sets the modified.
        /// </summary>
        DateTime? LastModified { get; set; }

        /// <summary>
        /// Gets or sets the name person that modified entity.
        /// </summary>
        string LastModifiedBy { get; set; }
    }
}