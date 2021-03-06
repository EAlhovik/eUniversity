﻿using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ViewModels.Dashboard;
using eUniversity.Business.ViewModels.Subject;
using SubjectViewModel = eUniversity.Business.ViewModels.Curriculum.SubjectViewModel;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for subject management service
    /// </summary>
    public interface ISubjectManagementService
    {
        void Save(IEnumerable<SubjectViewModel> subjects, Semester semester);
        void Delete(IEnumerable<Subject> subjects);

        IEnumerable<SubjectRowViewModel> GetRows();

        SubjectRowViewModel GetSubjectRowById(long id);
        void SaveSubject(SubjectRowViewModel viewModel);
        SubjectViewModel GetDiplom();
    }
}