using eUniversity.Business.ViewModels.Dashboard;

namespace eUniversity.Business.Domain.Contracts
{
    public interface IDashboardManagementService
    {
        StudentDashboardViewModel GetStudentDashboard();
        object GetProfessorDashboard();
    }
}