namespace eUniversity.Business.ViewModels.Profile
{
    /// <summary>
    /// View model for profile
    /// </summary>
    public class ProfileViewModel
    {
        public BasicProfileViewModel BasicProfile { get; set; }

        public SettingsViewModel Settings { get; set; }

        public ChangePasswordViewModel ChangePassword { get; set; }
    }
}