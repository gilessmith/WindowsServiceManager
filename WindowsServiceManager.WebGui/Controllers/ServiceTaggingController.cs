namespace WindowsServiceManager.WebGui.Controllers
{
    using System.Web.Mvc;

    using WindowsServiceManager.Core.Domain;
    using WindowsServiceManager.WebGui.Authorization;
    using WindowsServiceManager.WebGui.Models;

    [AuthorizeForServiceControl]
    public class ServiceTaggingController : Controller
    {
        private readonly IServiceTaggingModel model;

        public ServiceTaggingController(IServiceTaggingModel model)
        {
            this.model = model;
        }

        public void AddTag(string id, string tagText)
        {
            this.model.AddTag(ServiceId.CreateServiceIdFromServiceName(id), new Tag(tagText));
        }

        public void RemoveTag(string id, string tagText)
        {
            this.model.RemoveTag(ServiceId.CreateServiceIdFromServiceName(id), new Tag(tagText));
        }
    }
}