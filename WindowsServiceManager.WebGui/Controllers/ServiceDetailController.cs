namespace WindowsServiceManager.WebGui.Controllers
{
    using System.Web.Mvc;

    using WindowsServiceManager.WebGui.Models;

    public class ServiceDetailController : Controller
    {
        private readonly IServiceDetailModel model;

        public ServiceDetailController(IServiceDetailModel model)
        {
            this.model = model;
        }

        public JsonResult ListServices()
        {
            return this.Json(this.model.LoadHomeViewModel(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetServiceInfo(string id)
        {
            return this.Json(this.model.GetServiceInfo(id));
        }

    }
}