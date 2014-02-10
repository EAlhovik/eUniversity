namespace eUniversity.Business.ViewModels.Curriculum
{
    /// <summary>
    /// View model for curriculum row
    /// </summary>
    public class CurriculumRowViewModel : KnockoutViewModel
    {
        public long Id { get; set; }

        public string DateOfEnactment { get; set; }

        public string SpecializatoinName { get; set; }
    }
}