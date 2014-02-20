using eUniversity.Business.Helpers.Enums;

namespace eUniversity.Business.ViewModels.Curriculum
{
    /// <summary>
    /// View model for subject
    /// </summary>
    public class SubjectViewModel
    {
        public SelectedItemViewModel Subject { get; set; }
        public SelectedItemViewModel Assignee { get; set; }

        public SubjectTypeEnum SubjectType { get; set; }
    }
}