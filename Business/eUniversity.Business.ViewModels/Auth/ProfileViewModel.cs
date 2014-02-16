namespace eUniversity.Business.ViewModels.Auth
{
    /// <summary>
    /// View model for profile
    /// </summary>
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SelectedItemViewModel Group { get; set; }    
    }
}