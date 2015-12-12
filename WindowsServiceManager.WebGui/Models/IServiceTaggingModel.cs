namespace WindowsServiceManager.WebGui.Models
{
    using WindowsServiceManager.Core.Domain;

    public interface IServiceTaggingModel
    {
        void AddTag(ServiceId serviceId, Tag tag);

        void RemoveTag(ServiceId createServiceIdFromServiceName, Tag tag);
    }
}