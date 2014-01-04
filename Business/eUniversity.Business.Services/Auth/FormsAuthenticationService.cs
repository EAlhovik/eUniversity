using System.Web.Security;
using eUniversity.Business.Domain.Contracts;

namespace eUniversity.Business.Services.Auth
{
    /// <summary>
    /// Represnts forms authentication service
    /// </summary>
    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        /// <summary>
        /// Creates the password hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordFormat">The password format.</param>
        /// <returns> HASH </returns>
        public string CreatePasswordHash(string password, string passwordFormat = "SHA1")
        {
            if (string.IsNullOrEmpty(passwordFormat))
            {
                passwordFormat = "SHA1";
            }

            string saltAndPassword = string.Concat(password, "salt");
            string hashedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(
                    saltAndPassword, passwordFormat);
            return hashedPassword;
        }

        /// <summary>
        /// Creates an authentication ticket for the supplied user name and adds it to the cookies collection of the response, or to the URL if you are using cookieless authentication.
        /// </summary>
        /// <param name="userName">The name of an authenticated user. This does not have to map to a Windows account.</param>
        /// <param name="rememberMe">true to create a persistent cookie (one that is saved across browser sessions); otherwise, false.</param>
        public void SetAuthCookie(string userName, bool rememberMe)
        {
            FormsAuthentication.SetAuthCookie(userName, rememberMe);
        }

        /// <summary>
        /// Removes the forms-authentication ticket from the browser.
        /// </summary>
        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}