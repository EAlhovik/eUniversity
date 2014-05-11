using System;
using System.Collections.Generic;
using System.Linq;

namespace eUniversity.Business.ViewModels.Dashboard
{
    /// <summary>
    /// View model for student dashboard
    /// </summary>
    public class StudentDashboardViewModel
    {
        private IEnumerable<SemesterViewModel> semesters;
        public DateTime DateOfEnactment { get; set; }
        public IEnumerable<SemesterViewModel> Semesters
        {
            get
            {
                return semesters ?? (semesters = new List<SemesterViewModel>());
            }
            set
            {
                semesters = value;
            }
        }
    }
}