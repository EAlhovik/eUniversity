using eUniversity.Business.Helpers;
using eUniversity.Business.Helpers.Enums;

namespace eUniversity.Business.ViewModels.Curriculum
{
    /// <summary>
    /// View model for subject
    /// </summary>
    public class SubjectViewModel
    {
        public SelectedItemModel Subject { get; set; }
        public SelectedItemModel Assignee { get; set; }

        public SubjectTypeEnum SubjectType { get; set; }
    }
}