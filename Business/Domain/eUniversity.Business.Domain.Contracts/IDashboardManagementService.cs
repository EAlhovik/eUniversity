namespace eUniversity.Business.Domain.Contracts
{
    public interface IDashboardManagementService
    {
        object GetStudentDashboard();
        object GetProfessorDashboard();
    }
}