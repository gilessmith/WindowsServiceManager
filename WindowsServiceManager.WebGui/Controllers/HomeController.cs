namespace WindowsServiceManager.WebGui.Controllers
{
    using System.Web.Mvc;

    using WindowsServiceManager.WebGui.Authorization;
    using WindowsServiceManager.WebGui.Models;

    [AuthorizeForReadonly]
    public class HomeController : Controller
    {
        private readonly IHomeModel model;

        public HomeController(IHomeModel model)
        {
            this.model = model;
        }

        public ActionResult Index()
        {
            return this.View(this.model.LoadHomeViewModel());
        }
    }
}