using System;
using System.Collections.Generic;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Services
{
    public class SubjectService :BaseService<Subject>, ISubjectService
    {
        private ISubjectRepository SubjectRepository
        {
            get { return (ISubjectRepository)Repository; }
        }
        public SubjectService(ISubjectRepository repository)
            : base(repository)
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

        public override IEnumerable<Subject> All()
        {
            return SubjectRepository.GetSubjects();
        }

        #endregion
    }
}