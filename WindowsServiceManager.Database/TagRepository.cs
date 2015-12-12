namespace WindowsServiceManager.Database
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WindowsServiceManager.Core;
    using WindowsServiceManager.Core.Domain;

    public class TagRepository : ITagRepository
    {
        private readonly Func<ServiceTagContext> contextFactory;

        public TagRepository(Func<ServiceTagContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public bool TryRemoveTag(ServiceId serviceToUpdate, Tag tagToRemove, out string errorMessage)
        {
            using (var context = this.contextFactory())
            {
                var serviceId = serviceToUpdate.ServiceIdAsString();
                var matchingTags = context.ServiceTags.Where(st => st.ServiceId == serviceId && st.TagText == tagToRemove.TagText);

                if (!matchingTags.Any())
                {
                    errorMessage = string.Format("Could not find tag ({1}) to remove for service ({0}).", serviceId, tagToRemove);
                    return false;
                }

                if (matchingTags.Count() > 1)
                {
                    errorMessage =
                        string.Format(
                            "Found multiple tags [{2}] matching tag ({1}) being removed from service ({0}).",
                            serviceId,
                            tagToRemove,
                            string.Join(", ", matchingTags));
                    return false;
                }

                context.ServiceTags.Remove(matchingTags.Single());
                context.SaveChanges();

                errorMessage = string.Empty;
                return true;
            }
        }

        public bool TryAddTag(ServiceId serviceToUpdate, Tag tagToAdd, out string errorMessage)
        {
            using (var context = this.contextFactory())
            {
                var serviceName = serviceToUpdate.ServiceIdAsString();
                var matchingTags = context.ServiceTags.Where(st => st.ServiceId == serviceName && st.TagText == tagToAdd.TagText).ToList();

                if (matchingTags.Any())
                {
                    errorMessage = string.Format("Trying to add tag ({0}) to service ({1}) but there are already existing matching tags in the database [{2}].", tagToAdd, serviceToUpdate.ServiceIdAsString(), string.Join(", ", matchingTags));
                    return false;
                }

                context.ServiceTags.Add(new ServiceTag(){ServiceId = serviceName, TagText = tagToAdd.TagText });
                context.SaveChanges();

                errorMessage = string.Empty;
                return true;
            }
        }

        public ICollection<ServiceTag> LoadAll()
        {
            using (var context = this.contextFactory())
            {
                return context.ServiceTags.ToList();
            }
        }
    }
}