﻿using System.Collections.Generic;

namespace eUniversity.Business.ViewModels.Auth
{
    /// <summary>
    /// View model for register form
    /// </summary>
    public class RegisterFormViewModel
    {
        public RegisterViewModel Register { get; set; }
        public ProfileViewModel Profile { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}

