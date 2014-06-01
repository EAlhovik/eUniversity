using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Dashboard;
using eUniversity.Business.ViewModels.Theme;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.ManagementServices
{
    public class DashboardManagementService : IDashboardManagementService
    {
        private readonly IAuthorizationService authorizationService;
        private readonly IStudentProfileService studentProfileService;
        private readonly IStudentThemeService studentThemeService;
        private readonly IThemeService themeService;

        private readonly ICurriculumService curriculumService;
        private readonly IEUniversityUow universityUow;
        private readonly ISubjectManagementService subjectManagementService;
        private readonly IGroupService groupService;

        public DashboardManagementService(IAuthorizationService authorizationService, IStudentProfileService studentProfileService,
            ICurriculumService curriculumService, IStudentThemeService studentThemeService, IEUniversityUow universityUow,
            ISubjectManagementService subjectManagementService, IGroupService groupService, IThemeService themeService)
        {
            this.authorizationService = authorizationService;
            this.studentProfileService = studentProfileService;
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
                .Select(p => new ThemeRowViewModel()
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

        public ProfessorDashboardViewModel GetProfessorDashboard(FilterViewModel filter = null)
        {
            var viewModel = ApplyFilter(filter ?? GetDefaultFilter());
            return viewModel;
        }

        #endregion

        private ProfessorDashboardViewModel ApplyFilter(FilterViewModel filterViewModel)
        {
            var groupId = GetSelectedId(filterViewModel.Group);
            var semesterSeqId = GetSelectedId(filterViewModel.SemesterSeq);
            if (!groupId.HasValue || !semesterSeqId.HasValue)
            {
                return DefaultProfessorDashboard(filterViewModel);
            }

            var students = groupService.GetGroupStudents(groupId.Value);
            if (!students.Any())
            {
                return DefaultProfessorDashboard(filterViewModel);
            }
            var curriculum = curriculumService.GetCurriculumForStudent(students.First());
            var subjects = curriculum.Semesters.First(p => p.Sequential == semesterSeqId.Value).Subjects;


            return new ProfessorDashboardViewModel
            {
                Filter = filterViewModel,
                CountSubjects = subjects.Count,
                Students = students.Select(stud =>
                {
                    var student = studentProfileService.CreateOrOpen(stud);
                    return new StudentRowViewModel
                    {

                        Student = string.Format("{0} {1}", student.LastName, student.FirstName),
                        StudentId = student.Id,
                        Subjects = subjects.Select(subj =>
                        {
                            var studentTheme = studentThemeService.All().SingleOrDefault(p => p.SubjectId == subj.Id && p.StudentId == stud);
                            var subject = new StudentSubjectViewModel
                            {
                                Subject = subj.Name,
                                SubjectId = subj.Id
                            };

                            if (studentTheme != null)
                            {
                                subject.Theme = Mapper.Map<SelectedItemModel,SelectedItemViewModel>(themeService.GetSelectedItemById(studentTheme.ThemeId));
                                subject.ThemeId = studentTheme.ThemeId;
                            }
                            // if exist theme for this subject set it
                            return subject;
                        }).ToList()
                    };
                }).ToList()
            };
        }

        private static ProfessorDashboardViewModel DefaultProfessorDashboard(FilterViewModel filterViewModel)
        {
            return new ProfessorDashboardViewModel() {Filter = filterViewModel};
        }

        private static long? GetSelectedId(SelectedItemViewModel viewModel)
        {
            long id;
            if (viewModel != null && long.TryParse(viewModel.Id, out id))
            {
                return id;
            }
            return null;
        }

        private FilterViewModel GetDefaultFilter()
        {
            return new FilterViewModel
            {
                Group = new SelectedItemViewModel(),
                SemesterSeq = new SelectedItemViewModel()
            };
        }

        private IEnumerable<long> GetGroupStudents(long userId)
        {
            Group group = studentProfileService.GetUserGroup(userId);
            IEnumerable<long> groupStudents = groupService.GetGroupStudents(group.Id);
            return groupStudents.ToList();
        }

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