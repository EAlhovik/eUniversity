using eUniversity.Business.Helpers.Enums;

namespace eUniversity.Business.ViewModels.Auth
{
    /// <summary>
    /// View model for register user
    /// </summary>
    public class RegisterViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public AccountTypeEnum AccountType { get; set; }
    }
}