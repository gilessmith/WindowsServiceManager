namespace WindowsServiceManager.Core.Domain
{
    using System.Collections.Generic;

    public interface ICachedTagRepository
    {
        bool TryAddTag(ServiceId serviceToUpdate, Tag tagToAdd, out string errorMessage);

        bool TryRemoveTag(ServiceId serviceToUpdate, Tag tagToRemove, out string errorMessage);

        ICollection<Tag> TagsForService(ServiceId serviceId);

        ICollection<Tag> UniqueTags();
    }
}