using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<long> GetGroupStudents(long id)
        {
            return Repository.All()
                .Where(group => group.Id == id)
                .SelectMany(group => group.Students).Select(student => student.Id).ToList();
        }

        protected override Expression<Func<Group, bool>> Predicate(string term)
        {
            return group=>group.SpecializationId.HasValue &&
                (string.IsNullOrEmpty(term) || group.Name.ToUpper().IndexOf(term.ToUpper()) >= 0);
        }

        protected override bool HasAllRequired(Group entity)
        {
            return entity.SpecializationId.HasValue && !string.IsNullOrEmpty(entity.Name);
        }
    }
}