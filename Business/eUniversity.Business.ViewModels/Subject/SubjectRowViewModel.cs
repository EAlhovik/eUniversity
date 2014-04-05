using System.Collections.Generic;

namespace eUniversity.Business.ViewModels.Subject
{
    /// <summary>
    /// View model for subject row
    /// </summary>
    public class SubjectRowViewModel : KnockoutViewModel
    {
        public long Id { get; set; }
        public string SubjectName { get; set; }
        public string SemesterNumber { get; set; }
        public string CurriculumName { get; set; }
        public string SpecializationName { get; set; }

        public IEnumerable<ThemeViewModel> Themes
        {
            get
            {
                return themes ?? (new List<ThemeViewModel>());
            }
            set
            {
                themes = value;
            }
        }

        private IEnumerable<ThemeViewModel> themes;
    }
}