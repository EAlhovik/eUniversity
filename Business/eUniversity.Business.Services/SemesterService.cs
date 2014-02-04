using System;
using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.Services.Base;
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