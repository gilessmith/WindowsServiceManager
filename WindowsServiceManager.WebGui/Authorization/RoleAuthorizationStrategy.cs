namespace WindowsServiceManager.WebGui.Authorization
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Security;

    internal class RoleAuthorizationStrategy : IAuthorizationStrategy
    {
        public bool Authorize(HttpContextBase httpContext, IEnumerable<string> authorizedRoles)
        {
            var provider = new WindowsTokenRoleProvider();
            return authorizedRoles.Any(role => provider.IsUserInRole(httpContext.User.Identity.Name, role));
        }
    }
}