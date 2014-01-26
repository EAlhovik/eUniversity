using System.Collections.Generic;

namespace eUniversity.Business.ViewModels.Curriculum
{
    /// <summary>
    /// View model for curriculum
    /// </summary>
    public class CurriculumViewModel
    {
        public CurriculumHeaderViewModel CurriculumHeader { get; set; }

        public IEnumerable<SemesterViewModel> Semesters { get; set; }
    }
}