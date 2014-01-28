using System;
using System.Collections.Generic;
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
        public SemesterService(IRepository<Semester> repository) : base(repository)
        {
        }

        #region ISemesterService Members

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