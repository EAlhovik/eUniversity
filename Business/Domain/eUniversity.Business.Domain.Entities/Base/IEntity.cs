namespace eUniversity.Business.Domain.Entities.Base
{
    /// <summary>
    /// Base interface for entities in the system.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets entity id.
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// Checks if entity is new.
        /// </summary>
        /// <returns>Returns a value indicating whether provided entity is new (not added previously).</returns>
        bool IsNew();
    }
}