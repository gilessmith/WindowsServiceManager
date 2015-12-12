namespace WindowsServiceManager.WebGui.Controllers
{
    using System.Web.Mvc;

    using WindowsServiceManager.WebGui.Authorization;
    using WindowsServiceManager.WebGui.Models;

    [AuthorizeForServiceControl]
    public class ServiceActionController : Controller
    {
        private readonly IServiceActionModel model;

        public ServiceActionController(IServiceActionModel model)
        {
            this.model = model;
        }

        public ActionResult StopService(string id)
        {
            this.model.StopService(id);

            return this.RedirectToAction("Index");
        }

        public ActionResult StartService(string id)
        {
            this.model.StartService(id);

            return RedirectToAction("Index");
        }

        public ActionResult RestartService(string id)
        {
            this.model.RestartService(id);

            return RedirectToAction("Index");
        }

    }
}