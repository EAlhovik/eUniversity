using System.Collections.Generic;
using eUniversity.Business.ViewModels.Base;

namespace eUniversity.Business.ViewModels.Curriculum
{
    /// <summary>
    /// View model for curriculum
    /// </summary>
    public class CurriculumViewModel : IViewModel
    {
        public long Id { get; set; }

        public CurriculumHeaderViewModel CurriculumHeader { get; set; }

        public IEnumerable<SemesterViewModel> Semesters { get; set; }
    }
}