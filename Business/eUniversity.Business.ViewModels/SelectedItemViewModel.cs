namespace eUniversity.Business.ViewModels
{
    /// <summary>
    /// View model for selected item in select
    /// </summary>
    public class SelectedItemViewModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public bool Locked { get; set; }
    }
}