namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for forms authebtication service
    /// </summary>
    public interface IFormsAuthenticationService
    {
        /// <summary>
        /// Creates the password hash.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="passwordFormat">The password format.</param>
        /// <returns>HASH</returns>
        string CreatePasswordHash(string password, string passwordFormat = "SHA1");

        /// <summary>
        /// Creates an authentication ticket for the supplied user name and adds it to the cookies collection of the response, or to the URL if you are using cookieless authentication.
        /// </summary>
        /// <param name="userName">The name of an authenticated user. This does not have to map to a Windows account. 
        /// </param><param name="rememberMe">true to create a persistent cookie (one that is saved across browser sessions); otherwise, false. </param>
        void SetAuthCookie(string userName, bool rememberMe);

        /// <summary>
        /// Removes the forms-authentication ticket from the browser.
        /// </summary>
        void LogOut();
    }
}