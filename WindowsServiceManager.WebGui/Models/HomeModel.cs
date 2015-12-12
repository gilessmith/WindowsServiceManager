namespace WindowsServiceManager.WebGui.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using WindowsServiceManager.Core;
    using WindowsServiceManager.Core.Domain;
    using WindowsServiceManager.WebGui.ViewModels;

    public class HomeModel : IHomeModel
    {
        public HomeModel()
        {
        }

        public HomeViewModel LoadHomeViewModel()
        {
            var environmentName = System.Environment.MachineName;
            var userName = HttpContext.Current.User.Identity.Name;
            return new HomeViewModel(environmentName, userName);
        }
    }
}