using System;
using System.Linq.Expressions;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Services
{
    public class ThemeService : BaseService<Theme>, IThemeService
    {
        public ThemeService(IRepository<Theme> repository, IAuthorizationService authorizationService = null)
            : base(repository, authorizationService)
        {
        }

        #region BaseService Members

        protected override SelectedItemModel CreateSelectedItem(Theme item)
        {
            return new SelectedItemModel()
            {
                Id = item.Id.ToString(),
                Text = item.Name
            };
        }

        protected override Expression<Func<Theme, bool>> Predicate(string term)
        {
            return item =>
                string.IsNullOrEmpty(term) || item.Name.ToUpper().IndexOf(term.ToUpper()) >= 0;
        }

        #endregion

    }
}