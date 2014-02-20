using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Business.Domain.Entities.Base
{
    /// <summary>
    /// The entity for personal employee information
    /// </summary>
    public abstract class Profile : Entity
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the name of the middle.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        public GenderType? Gender { get; set; }

        public virtual User User { get; set; }
//        public long UserId { get; set; }
    }
}