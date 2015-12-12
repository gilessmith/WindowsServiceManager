namespace WindowsServiceManager.Database.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WindowsServiceManager.Core;
    using WindowsServiceManager.Core.Domain;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class CachedTagRepositoryTest
    {
        [Test]
        public void Constructor_WhenPassedNullRepository_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CachedTagRepository(null));
        }

        [Test]
        public void TryAddTag_DelegatesCallToRepository()
        {
            var repo = new Mock<ITagRepository>();
            var sut = new CachedTagRepository(repo.Object);

            var serviceId = ServiceId.CreateServiceIdFromServiceName("abc");
            var tag = new Tag("def");
            string errorMessage;

            sut.TryAddTag(serviceId, tag, out errorMessage);

            repo.Verify(r => r.TryAddTag(serviceId, tag, out errorMessage), Times.Once);
        }

        [Test]
        public void TagsForService_CalledMultipleTimesWithoutACacheRefresh_OnlyMakesASingleCallToTheRepository()
        {
            var repo = new Mock<ITagRepository>();
            repo.Setup(r => r.LoadAll()).Returns(new List<ServiceTag>());
            var sut = new CachedTagRepository(repo.Object);

            var serviceId = ServiceId.CreateServiceIdFromServiceName("abc");

            sut.TagsForService(serviceId);
            sut.TagsForService(serviceId);

            repo.Verify(r => r.LoadAll(), Times.Once);
        }

        [Test]
        public void TagsForService_WhenLoadingTagsForTwoServices_ReturnsTheTagsForJustTheServiceRequested()
        {
            var serviceIdToRequest = ServiceId.CreateServiceIdFromServiceName("abc");
            var tagForRequestedService = new Tag("zyx");

            var repo = new Mock<ITagRepository>();
            repo.Setup(r => r.LoadAll()).Returns(
                new List<ServiceTag>()
                    {
                        new ServiceTag() { ServiceId = serviceIdToRequest.ServiceIdAsString(), TagText = tagForRequestedService.TagText },
                        new ServiceTag() { ServiceId = "def", TagText = "wvu" }
                    });

            var sut = new CachedTagRepository(repo.Object);

            var tags = sut.TagsForService(serviceIdToRequest);

            Assert.That(tags.Count, Is.EqualTo(1));
            Assert.That(tags.First(), Is.EqualTo(tagForRequestedService));
        }

        [Test]
        public void TryAddTag_CausesCacheRefresh()
        {
            var repo = new Mock<ITagRepository>();
            repo.Setup(r => r.LoadAll()).Returns(new List<ServiceTag>());
            var sut = new CachedTagRepository(repo.Object);

            var serviceId = ServiceId.CreateServiceIdFromServiceName("abc");
            var tag = new Tag("def");
            string errorMessage;

            sut.TagsForService(serviceId);
            sut.TryAddTag(serviceId, tag, out errorMessage);
            sut.TagsForService(serviceId);

            repo.Verify(r => r.LoadAll(), Times.Exactly(2));
        }

        [Test]
        public void TryRemoveTag_CausesCacheRefresh()
        {
            var repo = new Mock<ITagRepository>();
            repo.Setup(r => r.LoadAll()).Returns(new List<ServiceTag>());
            var sut = new CachedTagRepository(repo.Object);

            var serviceId = ServiceId.CreateServiceIdFromServiceName("abc");
            var tag = new Tag("def");
            string errorMessage;

            sut.TagsForService(serviceId);
            sut.TryRemoveTag(serviceId, tag, out errorMessage);
            sut.TagsForService(serviceId);

            repo.Verify(r => r.LoadAll(), Times.Exactly(2));
        }
    }
}
