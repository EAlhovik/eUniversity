namespace eUniversity.Business.ViewModels.Dashboard
{
    /// <summary>
    /// View model for subject
    /// </summary>
    public class SubjectViewModel
    {
        public long Id { get; set; }
        public SelectedItemViewModel Assignee { get; set; }
        public string Name { get; set; }
        public string SubjectType { get; set; }
    }
}