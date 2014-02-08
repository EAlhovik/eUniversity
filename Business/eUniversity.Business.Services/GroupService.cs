using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Services
{
    public class GroupService : BaseService<Group>, IGroupService
    {
        public GroupService(IRepository<Group> repository, IAuthorizationService authorizationService = null) : base(repository, authorizationService)
        {
        }

        protected override Group CreateItem()
        {
            return new Group();
        }

        protected override SelectedItemModel CreateSelectedItem(Group item)
        {
            throw new System.NotImplementedException();
        }
    }
}