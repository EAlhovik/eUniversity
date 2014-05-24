using System.Collections.Generic;

namespace eUniversity.Business.ViewModels.Dashboard
{
    public class StudentRowViewModel
    {
        public string Student { get; set; }
        public long StudentId { get; set; }
        public IEnumerable<StudentSubjectViewModel> Subjects { get; set; }
    }

    public class StudentSubjectViewModel
    {
        public long ThemeId { get; set; }
        public SelectedItemViewModel Theme { get; set; }
        public string Subject { get; set; }
        public long SubjectId { get; set; }
    }
}