using System.Collections;
using System.Collections.Generic;

namespace eUniversity.Business.ViewModels.Membership
{
    /// <summary>
    /// View model for users
    /// </summary>
    public class MembershipViewModel
    {
        public IEnumerable<UserRowViewModel> Users { get; set; }
    }
}