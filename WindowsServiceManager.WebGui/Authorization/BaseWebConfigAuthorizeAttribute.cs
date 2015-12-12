namespace WindowsServiceManager.WebGui.Authorization
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public abstract class BaseWebConfigAuthorizeAttribute : AuthorizeAttribute
    {
        private static IAuthorizationStrategy authorisationStrategy = new NullAuthorizationStrategy();

        public static IAuthorizationStrategy AuthorizationStrategy
        {
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("AuthorizationStrategy");
                }

                authorisationStrategy = value;
            } 
        }

        protected abstract string RoleName { get; }
        
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return authorisationStrategy.Authorize(httpContext, this.GetAuthorizedRoles());
        }

        private IEnumerable<string> GetAuthorizedRoles()
        {
            var appSettings = ConfigurationManager.AppSettings[this.RoleName];
            if (string.IsNullOrEmpty(appSettings))
            {
                return new[] { string.Empty };
            }

            return appSettings.Split(',').Select(user => user.Trim());
        }
    }
}