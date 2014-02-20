﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Business.ViewModels.Subject;

namespace eUniversity.Business.ManagementServices
{
    /// <summary>
    /// Represents subject management service
    /// </summary>
    public class SubjectManagementService : ISubjectManagementService
    {
        private readonly ISubjectService subjectService;

        public SubjectManagementService(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        #region ISubjectManagementService Members

        public IEnumerable<SubjectRowViewModel> GetRows()
        {
            var subjects = subjectService.All();
            var viewModels = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectRowViewModel>>(subjects);
            return viewModels;
        }

        public void Save(IEnumerable<SubjectViewModel> subjects, Semester semester)
        {
            var originalSubjects = subjectService.All().Where(s => s.SemesterId == semester.Id);

            var modification = CollectionModificationResolver.Resolve(subjects, originalSubjects,
                                                                      (income, viewModel) =>
                                                                      income.Id == long.Parse(viewModel.Subject.Id));

            foreach (var item in modification.Modified)
            {
                SaveSubject(item.Key, item.Value);
            }

            foreach (var item in modification.Added)
            {
                var subject = new Subject() { Id = 0, Semester = semester };
                SaveSubject(item, subject);
            }

            foreach (var subject in modification.Deleted)
            {
                subjectService.Delete(subject);
            }
        }

        public void Delete(IEnumerable<Subject> subjects)
        {
//            subjects.ToList().ForEach(subject => subjectService.Delete(subject));
        }

        #endregion

        private void SaveSubject(SubjectViewModel viewModel, Subject subject)
        {
            subjectService.Save(subject);
            Mapper.Map<SubjectViewModel, Subject>(viewModel, subject);
        }
    }
}