using eUniversity.Business.ViewModels.Base;

namespace eUniversity.Business.ViewModels.Group
{
    /// <summary>
    /// View model for group
    /// </summary>
    public class GroupViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public SelectedItemViewModel Specialization { get; set; }
    }
}