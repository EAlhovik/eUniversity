using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    public class Role : Entity
    {
        public string RoleName { get; set; }

        public RoleEnum RoleType { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}