using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.Services.Base;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents semester service
    /// </summary>
    public class SemesterService : BaseService<Semester>, ISemesterService
    {
        private readonly ISubjectService subjectService;

        public SemesterService(IRepository<Semester> repository, ISubjectService subjectService)
            : base(repository)
        {
            this.subjectService = subjectService;
        }

        #region ISemesterService Members //todo: remove

        public void Save(IEnumerable<Semester> semesters)
        {
            throw new NotImplementedException();
        }

        public void Save(IEnumerable<SemesterViewModel> semesters)
        {
            foreach (var semesterViewModel in semesters)
            {
                var sem = Repository.GetById(semesterViewModel.Id);
                Repository.InsertOrUpdate(sem, true);
                Mapper.Map<SemesterViewModel, Semester>(semesterViewModel, sem);
            }
        }

        #endregion

        void IBaseService<Semester>.Delete(Semester semester)
        {
            if (semester.Subjects != null)
            {
                semester.Subjects.ToList().ForEach(subject => subjectService.Delete(subject));
            }
            base.Delete(semester);
        }

        #region BaseService Members

        protected override Semester CreateItem()
        {
            return new Semester();
        }

        protected override SelectedItemModel CreateSelectedItem(Semester item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}