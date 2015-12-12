namespace WindowsServiceManager.WebGui.Authorization
{
    using System.Collections.Generic;
    using System.Web;

    /// <summary>
    /// The Null AuthorizationStrategy can be used for testing where you do not want authorization to 
    /// apply. As the Authorize method always returns true, this obviously should not be used in production
    /// as it will grant access for all users. Setup of the authorization strategy is handled in the global.asax.cs file, 
    /// and controlled by the RoleAuthorizationDisabled app setting in the web config.
    /// </summary>
    public class NullAuthorizationStrategy : IAuthorizationStrategy
    {
        public bool Authorize(HttpContextBase httpContext, IEnumerable<string> authorizedRoles)
        {
            return true;
        }
    }
}