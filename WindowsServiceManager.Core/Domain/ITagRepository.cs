namespace WindowsServiceManager.Core.Domain
{
    using System.Collections.Generic;

    public interface ITagRepository
    {
        bool TryAddTag(ServiceId serviceToUpdate, Tag tagToAdd, out string errorMessage);

        bool TryRemoveTag(ServiceId serviceToUpdate, Tag tagToRemove, out string errorMessage);

        ICollection<ServiceTag> LoadAll();
    }
}