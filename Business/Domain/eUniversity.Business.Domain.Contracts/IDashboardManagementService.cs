using System.Collections.Generic;
using eUniversity.Business.ViewModels.Dashboard;
using eUniversity.Business.ViewModels.Theme;

namespace eUniversity.Business.Domain.Contracts
{
    public interface IDashboardManagementService
    {
        StudentDashboardViewModel GetStudentDashboard();
        ProfessorDashboardViewModel GetProfessorDashboard(FilterViewModel filter = null);
        SubjectDetailViewModel GetSubjectDetail(long subjectId);
        string IsThemeAvailable(long subjectId, long themeId);
        ThemeRowViewModel ChooseTheme(long subjectId, ThemeRowViewModel theme);
        IEnumerable<ThemeRowViewModel> GetSubjectThemes(long subjectId);
        void UnsubscribeFromTheme(long subjectId, long themeId);
    }
}