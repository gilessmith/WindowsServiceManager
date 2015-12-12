namespace WindowsServiceManager.Database.IntegrationTests
{
    using System.Linq;

    using NUnit.Framework;

    using WindowsServiceManager.Core.Domain;

    [TestFixture]
    public class TagRepositoryTests
    {
        private TestingContextFactory contextFactory;
        
        [SetUp]
        public void Initialise()
        {
            this.contextFactory = new TestingContextFactory();
        }

        [Test]
        public void TryAddTag_AServiceTagThatDoesntAlreadyExist_AddsItemToAllItems()
        {
            var serviceId = "abc";
            var tagText = "def";

            var r = this.CreateRepository();
            var initialItems = r.LoadAll();
            Assert.That(initialItems, Is.Empty);

            string msg;
            var result = r.TryAddTag(ServiceId.CreateServiceIdFromServiceName(serviceId), new Tag(tagText), out msg);
            var finalItems = r.LoadAll();

            Assert.That(result, Is.True);
            Assert.That(finalItems.Count, Is.EqualTo(1));
            Assert.That(finalItems.First().ServiceId, Is.EqualTo(serviceId));
            Assert.That(finalItems.First().TagText, Is.EqualTo(tagText));
        }

        [Test]
        public void TryAddTag_AServiceTagThatAlreadyExists_FailsToAddNewItem()
        {
            var serviceId = "abc";
            var tagText = "def";

            var r = this.CreateRepository();

            string msg;
            var resultSuccessfulResult = r.TryAddTag(ServiceId.CreateServiceIdFromServiceName(serviceId), new Tag(tagText), out msg);
            var result = r.TryAddTag(ServiceId.CreateServiceIdFromServiceName(serviceId), new Tag(tagText), out msg);

            Assert.That(resultSuccessfulResult, Is.True);
            Assert.That(result, Is.False);
        }

        [Test]
        public void TryRemoveTag_ThatDoesntExist_ReturnsFalse()
        {
            var serviceId = "abc";
            var tagText = "def";

            var r = this.CreateRepository();

            string msg;
            var result = r.TryRemoveTag(ServiceId.CreateServiceIdFromServiceName(serviceId), new Tag(tagText), out msg);

            Assert.That(result, Is.False);
        }

        [Test]
        public void TryRemoveTag_ThatExists_ReturnsTrueAndRemovesTag()
        {
            var serviceId = "abc";
            var tagText = "def";

            var r = this.CreateRepository();

            string msg;
            r.TryAddTag(ServiceId.CreateServiceIdFromServiceName(serviceId), new Tag(tagText), out msg);
            var intermediateTags = r.LoadAll();
            var result = r.TryRemoveTag(ServiceId.CreateServiceIdFromServiceName(serviceId), new Tag(tagText), out msg);
            var finalTags = r.LoadAll();

            Assert.That(result, Is.True);
            Assert.That(intermediateTags.Count, Is.EqualTo(1));
            Assert.That(finalTags.Count, Is.EqualTo(0));
        }

        private TagRepository CreateRepository()
        {
            return new TagRepository(() => this.contextFactory.CreateContext());
        }
    }
}
