using System;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services
{
    public class SubjectService :BaseService<Subject>, ISubjectService
    {
        public SubjectService(IRepository<Subject> repository) : base(repository)
        {
        }
        
        #region BaseService Members

        protected override Subject CreateItem()
        {
            return new Subject();
        }

        protected override SelectedItemModel CreateSelectedItem(Subject item)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}