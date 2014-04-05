using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Services
{
    public class SubjectService : BaseService<Subject>, ISubjectService
    {
        private readonly IRepository<Theme> themeRepository;
        private ISubjectRepository SubjectRepository
        {
            get { return (ISubjectRepository)Repository; }
        }
        public SubjectService(ISubjectRepository repository, IRepository<Theme> themeRepository)
            : base(repository)
        {
            this.themeRepository = themeRepository;
        }

        #region BaseService Members

        public void UpdateSubjectThemes(Subject subject)
        {
            var dbSubject = SubjectRepository.GetById(subject.Id);
            var modification = CollectionModificationResolver.Resolve(subject.Themes, dbSubject.Themes,
                (income, viewModel) => income.Id == viewModel.Id);

            foreach (var item in modification.Added)
            {
                dbSubject.Themes.Add(themeRepository.GetById(item.Id));
            }
//            foreach (var theme in modification.Modified) miss the same themes
            foreach (var theme in modification.Deleted)
            {
                dbSubject.Themes.Remove(theme);
            }
        }

        protected override SelectedItemModel CreateSelectedItem(Subject item)
        {
            return new SelectedItemModel()
            {
                Id = item.Id.ToString(),
                Text = item.Name
            };
        }

        public override IEnumerable<Subject> All()
        {
            return SubjectRepository.GetSubjects();
        }

        protected override Expression<Func<Subject, bool>> Predicate(string term)
        {
            return item => item.Name.ToUpper().IndexOf(term.ToUpper()) >= 0;
        }

        #endregion
    }
}