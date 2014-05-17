using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.Enums;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Business.ViewModels.Subject;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices
{
    /// <summary>
    /// Represents subject management service
    /// </summary>
    public class SubjectManagementService : ISubjectManagementService
    {
        private readonly ISubjectService subjectService;
        private readonly IEUniversityUow universityUow;

        public SubjectManagementService(ISubjectService subjectService, IEUniversityUow universityUow)
        {
            this.subjectService = subjectService;
            this.universityUow = universityUow;
        }

        #region ISubjectManagementService Members

        public void SaveSubject(SubjectRowViewModel viewModel)
        {
            var subject = Mapper.Map<SubjectRowViewModel, Subject>(viewModel);
            subjectService.UpdateSubjectThemes(subject);

            universityUow.Commit();
        }

        public SubjectRowViewModel GetSubjectRowById(long id)
        {
            var subject = subjectService.CreateOrOpen(id);
            var viewModel = Mapper.Map<Subject, SubjectRowViewModel>(subject);
            return viewModel;
        }

        public IEnumerable<SubjectRowViewModel> GetRows()
        {
            var subjects = subjectService.All();
            var viewModels = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectRowViewModel>>(subjects);
            return viewModels;
        }

        public void Save(IEnumerable<SubjectViewModel> subjects, Semester semester)
        {
            var originalSubjects = subjectService.All().Where(s => s.SemesterId == semester.Id);

            var modification = CollectionModificationResolver.Resolve(subjects.Where(s => IdChecker(s.Id)), originalSubjects,
                                                                      (income, viewModel) =>
                                                                      income.Id == long.Parse(viewModel.Id));

            foreach (var item in modification.Modified)
            {
                SaveSubject(item.Key, item.Value);
            }

            AddNewSubjects(semester, subjects.Where(s => !IdChecker(s.Id)));
            AddNewSubjects(semester, modification.Added);

            foreach (var subject in modification.Deleted)
            {
                subjectService.Delete(subject);
            }
        }

        private static bool IdChecker(string subjectId)
        {
            long id;
            return long.TryParse(subjectId, out id);
        }

        private void AddNewSubjects(Semester semester, IEnumerable<SubjectViewModel> subjectViewModels)
        {
            foreach (var item in subjectViewModels)
            {
                var subject = new Subject();
                if (IdChecker(item.Id))
                {
                    var dbSubject = subjectService.CreateOrOpen(long.Parse(item.Id));
                    Mapper.Map<Subject, Subject>(dbSubject, subject);
                    subject.Id = 0;
                }
                else
                {
                    subject.Id = 0;
                    subject.Name = SubjectIdPrefixHelper.Trim(item.Id);
                }

                subject.Semester = semester;
                SaveSubject(item, subject);
            }
        }

        public void Delete(IEnumerable<Subject> subjects)
        {
//            subjects.ToList().ForEach(subject => subjectService.Delete(subject));
        }

        public SubjectViewModel GetDiplom()
        {
            return new SubjectViewModel
            {
                Id = "Diplom+",
                SubjectType = ((int)SubjectTypeEnum.Diplom).ToString()
            };
        }

        #endregion

        private void SaveSubject(SubjectViewModel viewModel, Subject subject)
        {
            subjectService.Save(subject);
            Mapper.Map<SubjectViewModel, Subject>(viewModel, subject);
        }
    }
}