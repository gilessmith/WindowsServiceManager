namespace WindowsServiceManager.WebGui.Authorization
{
    using System.Collections.Generic;
    using System.Web;

    public interface IAuthorizationStrategy
    {
        bool Authorize(HttpContextBase httpContext, IEnumerable<string> authorizedRoles);
    }
}