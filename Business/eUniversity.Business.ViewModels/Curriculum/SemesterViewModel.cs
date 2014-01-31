using System.Collections.Generic;

namespace eUniversity.Business.ViewModels.Curriculum
{
    /// <summary>
    /// View model for semester
    /// </summary>
    public class SemesterViewModel
    {

        public long Id { get; set; }
        public int Sequential { get; set; }

        public IEnumerable<SubjectViewModel> Subjects
        {
            get
            {
                return subjects ?? (subjects = new List<SubjectViewModel>());
            }
            set
            {
                subjects = value;
            }
        }

        #region private fields

        private IEnumerable<SubjectViewModel> subjects;

        #endregion
    }
}