namespace eUniversity.Business.ViewModels.Profile
{
    /// <summary>
    /// View model for profile
    /// </summary>
    public class BasicProfileViewModel
    {
        public GeneralInfoSectionViewModel GeneralSection { get; set; }

        public ContactInfoSectionViewModel ContactSection { get; set; }
        public SocialInfoSectionViewModel SocialSection { get; set; }
    }
}