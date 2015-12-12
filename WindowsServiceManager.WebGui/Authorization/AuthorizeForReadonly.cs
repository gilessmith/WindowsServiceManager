namespace WindowsServiceManager.WebGui.Authorization
{
    using System;

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class AuthorizeForReadonlyAttribute : BaseWebConfigAuthorizeAttribute
    {
        protected override string RoleName
        {
            get
            {
                return "ReadOnlyUsers";
            }
        }
    }
}