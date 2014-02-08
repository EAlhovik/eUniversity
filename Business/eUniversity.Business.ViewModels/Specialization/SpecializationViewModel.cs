using eUniversity.Business.ViewModels.Base;

namespace eUniversity.Business.ViewModels.Specialization
{
    /// <summary>
    /// View model for specialization
    /// </summary>
    public class SpecializationViewModel : IViewModel
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

        public long? SpecialityId { get; set; }
    }
}