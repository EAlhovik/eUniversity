using eUniversity.Business.Helpers.Enums;

namespace eUniversity.Business.ViewModels.Curriculum
{
    /// <summary>
    /// View model for subject
    /// </summary>
    public class SubjectViewModel
    {
        public string Id { get; set; }
        public SelectedItemViewModel Assignee { get; set; }

        public string SubjectType { get; set; }
    }
}