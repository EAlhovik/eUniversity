namespace eUniversity.Business.ViewModels.Profile
{
    /// <summary>
    /// View model for gerental info section
    /// </summary>
    public class GeneralInfoSectionViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BithDayDisplay { get; set; }
        public bool? IsMale { get; set; } //todo: change to enum
        public string Comment { get; set; }
    }
}