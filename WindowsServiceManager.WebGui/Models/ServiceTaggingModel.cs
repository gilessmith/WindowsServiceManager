namespace WindowsServiceManager.WebGui.Models
{
    using WindowsServiceManager.Core.Domain;

    public class ServiceTaggingModel : IServiceTaggingModel
    {
        private ICachedTagRepository tagRepository;

        public ServiceTaggingModel(ICachedTagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public void AddTag(ServiceId serviceId, Tag tag)
        {
            string msg;
            this.tagRepository.TryAddTag(serviceId, tag, out msg);
        }

        public void RemoveTag(ServiceId createServiceIdFromServiceName, Tag tag)
        {
            string msg;
            this.tagRepository.TryRemoveTag(createServiceIdFromServiceName, tag, out msg);
        }
    }
}