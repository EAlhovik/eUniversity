using System.Collections.Generic;
using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents group service
    /// </summary>
    public class GroupService : BaseService<Group>, IGroupService
    {
        public GroupService(IRepository<Group> repository, IAuthorizationService authorizationService = null) : base(repository, authorizationService)
        {
        }

        protected override SelectedItemModel CreateSelectedItem(Group item)
        {
            return new SelectedItemModel
            {
                Id = item.Id.ToString(),
                Text = item.Name
            };
        }

        /// <summary>
        /// Gets the selected items.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns>Selected item by term</returns>
        public override IEnumerable<SelectedItemModel> GetSelectedItems(string term)
        {
            return Repository.All()
                .Where(group => string.IsNullOrEmpty(term) || group.Name.ToUpper().IndexOf(term.ToUpper()) >= 0)
                .Select(CreateSelectedItem);
        }
    }
}