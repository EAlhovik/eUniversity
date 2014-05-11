using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Dashboard;

namespace eUniversity.Business.ManagementServices
{
    public class DashboardManagementService : IDashboardManagementService
    {
        private readonly IAuthorizationService authorizationService;
        private readonly IStudentProfileService studentProfileService;
        private readonly IUserService userService;

        private readonly ICurriculumService curriculumService;

        public DashboardManagementService(IAuthorizationService authorizationService, IStudentProfileService studentProfileService,
            IUserService userService, ICurriculumService curriculumService)
        {
            this.authorizationService = authorizationService;
            this.studentProfileService = studentProfileService;
            this.userService = userService;
            this.curriculumService = curriculumService;
        }

        #region IDashboardManagementService Members

        public StudentDashboardViewModel GetStudentDashboard()
        {
            var profile = studentProfileService.CreateOrOpen(authorizationService.CurrentUser.Id);
            var specialization = studentProfileService.GetUserSpecialization(profile.Id);
            var dateOfAdmission = DateTime.Now.Date.AddYears(-2);//profile.DateOfAdmission; //

            var curriculum = curriculumService.GetCurriculumForStudent(specialization.Id, dateOfAdmission);

            var viewModel = Mapper.Map<Curriculum, StudentDashboardViewModel>(curriculum);

            UpdateSemesters(viewModel);
            return viewModel;
        }

        public object GetProfessorDashboard()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void UpdateSemesters(StudentDashboardViewModel viewModel)
        {
            foreach (var semester in viewModel.Semesters)
            {
                var semesterPeriod = new SemesterPeriod(viewModel.DateOfEnactment, semester.Sequential);
                var compareResult = semesterPeriod.Compare(DateTime.Now);

                if (compareResult < 0)
                {
                    semester.IsReadOnly = true;
                }
                else if (compareResult == 0)
                {
                    // current semester
                }
            }
        }

        private class SemesterPeriod
        {
            public SemesterPeriod(DateTime dateOfEnactmentCurriculum, int sequential)
            {
                start = new DateTime(dateOfEnactmentCurriculum.Year, 9, 1);
                end = start.AddMonths(6);
                for (int i = 2; i < sequential; i++)
                {
                    start = start.AddMonths(6);
                    end = start.AddMonths(6);
                }
            }

            private readonly DateTime start;
            private readonly DateTime end;

            public int Compare(DateTime value)
            {
                var result = 0;
                if (value < start)
                {
                    result = -1;
                }
                else if (value >= start && value < end)
                {
                    result = 0;
                }
                else if (value >= end)
                {
                    result = 1;
                }
                return result;
            }
        }
    }
}