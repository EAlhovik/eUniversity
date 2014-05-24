using System.Collections.Generic;

namespace eUniversity.Business.ViewModels.Dashboard
{
    /// <summary>
    /// View model for professor dashboard
    /// </summary>
    public class ProfessorDashboardViewModel
    {
        public FilterViewModel Filter { get; set; }

        public IEnumerable<StudentRowViewModel> Students { get; set; }

        public long CountSubjects { get; set; }
    }
}