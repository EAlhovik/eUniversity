using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.ViewModels.Curriculum;

namespace eUniversity.Business.ManagementServices
{
    /// <summary>
    /// Represents semester management service
    /// </summary>
    public class SemesterManagementService : ISemesterManagementService
    {
        private readonly ISemesterService semesterService;
        private readonly ISubjectManagementService subjectManagementService;

        public SemesterManagementService(ISemesterService semesterService, ISubjectManagementService subjectManagementService)
        {
            this.semesterService = semesterService;
            this.subjectManagementService = subjectManagementService;
        }

        public IEnumerable<SemesterViewModel> GetSemesters(long? curriculumId)
        {
            if (!curriculumId.HasValue || curriculumId.Value == 0)
            {
                return Enumerable.Range(1, 8).Select(p => new SemesterViewModel() { Sequential = p });
            }
            return Enumerable.Empty<SemesterViewModel>();
        }

        public void Save(IEnumerable<SemesterViewModel> semesters, Curriculum curriculum)
        {
            var originalSemesters = semesterService.All().Where(s => s.CurriculumId == curriculum.Id);
            var modification = CollectionModificationResolver.Resolve(semesters, originalSemesters,
                (income, viewModel) => income.Id == viewModel.Id);

            foreach (var item in modification.Modified)
            {
                SaveSemester(item.Key, item.Value);
            }

            foreach (var item in modification.Added)
            {
                var semester = new Semester { Id = item.Id, Curriculum = curriculum };
                SaveSemester(item, semester);
            }

            foreach (var semester in modification.Deleted)
            {
                subjectManagementService.Delete(semester.Subjects);
                semesterService.Delete(semester);
            }
        }

        public IEnumerable<SemesterViewModel> CreateSemesters(int count)
        {
            var semesters = new List<SemesterViewModel>();
            for (int i = 0; i < count; i++)
            {
                var semester = new SemesterViewModel()
                {
                    Sequential = i + 1
                };
                if (i == count - 1)
                {
                    semester.Subjects.Add(subjectManagementService.GetDiplom());
                }
                semesters.Add(semester);

            }
            return semesters;
        }

        private void SaveSemester(SemesterViewModel viewModel, Semester semester)
        {
            semesterService.Save(semester);
            Mapper.Map<SemesterViewModel, Semester>(viewModel, semester);
            subjectManagementService.Save(viewModel.Subjects, semester);

        }
    }
}