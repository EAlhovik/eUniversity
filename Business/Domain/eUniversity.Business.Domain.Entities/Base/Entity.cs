using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Serialization;

namespace eUniversity.Business.Domain.Entities.Base
{
    /// <summary>
    /// Base class for entitities.
    /// </summary>
    [DebuggerDisplay("Id = {Id}")]
    public class Entity : IEntity
    {
        /// <summary>
        /// Gets or sets object id.
        /// </summary>
        [XmlIgnore]
        [Key]
        public long Id
        {
            get;
            set;
        }

        /// <summary>
        /// Checks if entity is new.
        /// </summary>
        /// <returns>Returns a value indicating whether provided entity is new (not added previously).</returns>
        public bool IsNew()
        {
            return (Id == 0);
        }
    }
}