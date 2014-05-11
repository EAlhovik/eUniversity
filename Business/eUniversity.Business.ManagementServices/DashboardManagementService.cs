using System;
using eUniversity.Business.Domain.Contracts;

namespace eUniversity.Business.ManagementServices
{
    public class DashboardManagementService: IDashboardManagementService
    {
        private readonly IAuthorizationService authorizationService;

        public DashboardManagementService(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        #region IDashboardManagementService Members

        public object GetStudentDashboard()
        {
            throw new NotImplementedException();
        }
        public object GetProfessorDashboard()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}