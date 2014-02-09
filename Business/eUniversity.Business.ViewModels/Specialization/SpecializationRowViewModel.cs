namespace eUniversity.Business.ViewModels.Specialization
{
    /// <summary>
    /// View model for specialization row
    /// </summary>
    public class SpecializationRowViewModel : KnockoutViewModel
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