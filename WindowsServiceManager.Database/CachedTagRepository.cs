namespace WindowsServiceManager.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WindowsServiceManager.Core;
    using WindowsServiceManager.Core.Domain;

    public class CachedTagRepository : ICachedTagRepository
    {
        private readonly ITagRepository repository;

        private Dictionary<ServiceId, ICollection<Tag>> cachedTagsDictionary;

        private bool alreadyLoaded;

        private ICollection<Tag> distinctTags;

        public CachedTagRepository(ITagRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            this.repository = repository;
        }

        public bool TryAddTag(ServiceId serviceToUpdate, Tag tagToAdd, out string errorMessage)
        {
            var result = this.repository.TryAddTag(serviceToUpdate, tagToAdd, out errorMessage);
            this.ClearCache();

            return result;
        }

        public bool TryRemoveTag(ServiceId serviceToUpdate, Tag tagToRemove, out string errorMessage)
        {
            var result = this.repository.TryRemoveTag(serviceToUpdate, tagToRemove, out errorMessage);
            this.ClearCache();

            return result;
        }

        public ICollection<Tag> TagsForService(ServiceId serviceId)
        {
            var allTags = this.AllTagsByService();
            if (!allTags.ContainsKey(serviceId))
            {
                return new List<Tag>();
            }

            return allTags[serviceId];
        }

        public ICollection<Tag> UniqueTags()
        {
            if (!this.alreadyLoaded)
            {
                this.LoadTags();
                this.alreadyLoaded = true;
            }

            return this.distinctTags;
        }

        private void ClearCache()
        {
            this.alreadyLoaded = false;
        }
        
        private Dictionary<ServiceId, ICollection<Tag>> AllTagsByService()
        {
            if (!this.alreadyLoaded)
            {
                this.LoadTags();
                this.alreadyLoaded = true;
            }

            return this.cachedTagsDictionary;
        }

        private void LoadTags()
        {
            var serviceTags = this.repository.LoadAll();

            this.cachedTagsDictionary = serviceTags
                .GroupBy(st => ServiceId.CreateServiceIdFromServiceName(st.ServiceId))
                .ToDictionary(st => st.Key, st => (ICollection<Tag>)st.Select(t => new Tag(t.TagText)).ToList());

            this.distinctTags = serviceTags.Select(st => new Tag(st.TagText)).Distinct().ToList();
        }
    }
}