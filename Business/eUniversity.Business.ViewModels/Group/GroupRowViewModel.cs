using eUniversity.Business.ViewModels.Base;

namespace eUniversity.Business.ViewModels.Group
{
    /// <summary>
    /// View model for group row view model
    /// </summary>
    public class GroupRowViewModel : KnockoutViewModel, IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}