using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Dashboard;
using eUniversity.Business.ViewModels.Theme;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices
{
    public class DashboardManagementService : IDashboardManagementService
    {
        private readonly IAuthorizationService authorizationService;
        private readonly IStudentProfileService studentProfileService;
        private readonly IUserService userService;
        private readonly IStudentThemeService studentThemeService;
        private readonly IThemeService themeService;

        private readonly ICurriculumService curriculumService;
        private readonly IEUniversityUow universityUow;
        private readonly ISubjectManagementService  subjectManagementService;
        private readonly IGroupService groupService;

        public DashboardManagementService(IAuthorizationService authorizationService, IStudentProfileService studentProfileService,
            IUserService userService, ICurriculumService curriculumService, IStudentThemeService studentThemeService, IEUniversityUow universityUow, ISubjectManagementService subjectManagementService, IGroupService groupService, IThemeService themeService)
        {
            this.authorizationService = authorizationService;
            this.studentProfileService = studentProfileService;
            this.userService = userService;
            this.curriculumService = curriculumService;
            this.studentThemeService = studentThemeService;
            this.universityUow = universityUow;
            this.subjectManagementService = subjectManagementService;
            this.groupService = groupService;
            this.themeService = themeService;
        }

        #region IDashboardManagementService Members

        public void UnsubscribeFromTheme(long subjectId, long themeId)
        {
            var userId = authorizationService.CurrentUser.Id;
            var subscribe = studentThemeService.All()
                .Single(p => p.StudentId == userId && p.SubjectId == subjectId && p.ThemeId == themeId);
            studentThemeService.Delete(subscribe);
            universityUow.Commit();
        }

        public SubjectDetailViewModel GetSubjectDetail(long subjectId)
        {
            var detail = new SubjectDetailViewModel()
            {
                Id = subjectId,
            };
            var userId = authorizationService.CurrentUser.Id;

            var theme = studentThemeService.All()
                .SingleOrDefault(p => p.SubjectId == subjectId && p.StudentId == userId);
            if (theme != null)
            {
                var t = themeService.CreateOrOpen(theme.ThemeId);
                detail.Theme = t.Name;
                detail.ThemeId = t.Id;
            }
            return detail;

        }

        public IEnumerable<ThemeRowViewModel> GetSubjectThemes(long subjectId)
        {
            return subjectManagementService.GetSubjectRowById(subjectId)
                .Themes
                .Select(p=>new ThemeRowViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description
                });
        }

        public StudentDashboardViewModel GetStudentDashboard()
        {//todo: if curriculum doesn't exist send empty model
            var dateOfAdmission = studentProfileService.GetDateOfAdmission(authorizationService.CurrentUser.Id);
            var specialization = studentProfileService.GetUserSpecialization(authorizationService.CurrentUser.Id);

            var curriculum = curriculumService.GetCurriculumForStudent(specialization.Id, dateOfAdmission);

            var viewModel = Mapper.Map<Curriculum, StudentDashboardViewModel>(curriculum);

            UpdateSemesters(viewModel);
            return viewModel;
        }

        public string IsThemeAvailable(long subjectId, long themeId)
        {
            bool isAllowedMultipleThemeChoice = false;
            var userId = authorizationService.CurrentUser.Id;
            IEnumerable<long> groupStudents = GetGroupStudents(userId);

            var themes = studentThemeService.All()
                .Where(p => p.ThemeId == themeId && p.SubjectId == subjectId && groupStudents.Contains(p.StudentId));

            if (isAllowedMultipleThemeChoice)
            {
                if (themes.Any(p => p.StudentId == userId))
                {
                    return "Вы уже выбрали эту тему.";
                    throw new Exception(string.Format("this theme alreany selected. subjectId='{0}' themeId='{1}' userId='{2}'", subjectId, themeId, userId));
                }
                else
                {
                    return null;
                }
            }
            else
            {
                if (themes.Any())
                {
                    return "Эта тема уже выбрана.";
                    throw new Exception(string.Format("Option exception. Only one time theme can be selected. subjectId='{0}' themeId='{1}' userId='{2}'", subjectId, themeId, userId));
                }
                return null;
            }
        }

        private IEnumerable<long> GetGroupStudents(long userId)
        {
            Group group = studentProfileService.GetUserGroup(userId);
            IEnumerable<long> groupStudents = groupService.GetGroupStudents(group.Id);
            return groupStudents.ToList();
        }

        public ThemeRowViewModel ChooseTheme(long subjectId, ThemeRowViewModel theme)
        {
            var userId = authorizationService.CurrentUser.Id;
            studentThemeService.Save(new StudentTheme
            {
                ThemeId = theme.Id,
                StudentId = userId,
                SubjectId = subjectId
            });
            universityUow.Commit();
            return theme;
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
                    semester.IsCurrent = true;
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
                for (int i = 1; i < sequential; i++)
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