using System;

namespace eUniversity.Business.Domain.Entities.Base
{
    /// <summary>
    /// Interface for entities with history
    /// </summary>
    public interface IEntityChanged : IEntity
    {
        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the name person that created entity.
        /// </summary>
        string CreatedBy { get; set; }
    }
}