using eUniversity.Business.ViewModels.Base;

namespace eUniversity.Business.ViewModels.Speciality
{
    /// <summary>
    /// View model for speciality row
    /// </summary>
    public class SpecialityRowViewModel: KnockoutViewModel, IViewModel
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
    }
}