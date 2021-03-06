﻿using System;
using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    public class User : Entity, IHasCreation
    {
        public string Email { get; set; }
        //        public System.DateTime LastActivityDate { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public string Password { get; set; }

        //public string PasswordSalt { get; set; }
        //public string Email { get; set; }
        public bool IsApproved { get; set; }
        //public bool IsLockedOut { get; set; }

        public Profile Profile { get; set; }
        public long? PersonId { get; set; }

        #region IHasCreation Members

        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }

        #endregion

    }
}