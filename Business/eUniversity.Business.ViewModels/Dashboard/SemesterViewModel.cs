using System.Collections.Generic;
using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Business.ViewModels.Dashboard
{
    public class SemesterViewModel
    {
        public long Id { get; set; }
        public int Sequential { get; set; }
        public bool IsReadOnly { get; set; }

        public ICollection<ViewModels.Dashboard.SubjectViewModel> Subjects
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

        private ICollection<SubjectViewModel> subjects;

        #endregion
    }
}