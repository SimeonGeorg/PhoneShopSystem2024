using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PhoneCatalog.Core.Services;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PhoneCatalog.UnitTests.Services
{
    [TestFixture]
    public class PhoneServiceTests
    {
        private PhoneService phoneService;
        private Mock<IRepository> mockRepository;

        [SetUp]
        public void Setup()
        {
            
            mockRepository = new Mock<IRepository>();

            
            phoneService = new PhoneService(mockRepository.Object);
        }

        [Test]
        public async Task AllPhonesAsync_ReturnsAllPhones()
        {
            // Arrange
            var phones = new List<Phone>
            {
                new Phone { Id = 1, Brand = "Brand1", Model = "Model1", ImageUrl = "Image1.jpg" },
                new Phone { Id = 2, Brand = "Brand2", Model = "Model2", ImageUrl = "Image2.jpg" }
            }.AsQueryable();

            mockRepository.Setup(r => r.AllNoTracking<Phone>()).Returns(phones);

            // Act
            var result = await phoneService.AllPhonesAsync();

            // Assert
            Assert.AreEqual(phones.Count(), result.Count());
            Assert.AreEqual(phones.First().Brand, result.First().Brand);
        }

        [Test]
        public async Task AllPhonesByOwnerIdAsync_ReturnsPhonesForGivenOwnerId()
        {
            // Arrange
            int ownerId = 1;
            var phones = new List<Phone>
            {
                new Phone { Id = 1, OwnerId = 1, Brand = "Brand1", Model = "Model1", ImageUrl = "Image1.jpg" },
                new Phone { Id = 2, OwnerId = 1, Brand = "Brand2", Model = "Model2", ImageUrl = "Image2.jpg" },
                new Phone { Id = 3, OwnerId = 2, Brand = "Brand3", Model = "Model3", ImageUrl = "Image3.jpg" }
            }.AsQueryable();

            
            mockRepository.Setup(r => r.AllNoTracking<Phone>()).Returns(phones);

            // Act
            var result = await phoneService.AllPhonesByOwnerIdAsync(ownerId);

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.All(p => p.Comments.Any(c=>c.OwnerId == ownerId)));
        }

        [Test]
        public async Task AllPhonesByOwnerIdAsync_ReturnsEmptyListWhenNoPhonesFoundForGivenOwnerId()
        {
            // Arrange
            int ownerId = 1;
            var phones = new List<Phone>().AsQueryable();

            mockRepository.Setup(r => r.AllNoTracking<Phone>()).Returns(phones);

            // Act
            var result = await phoneService.AllPhonesByOwnerIdAsync(ownerId);

            // Assert
            Assert.AreEqual(0, result.Count());
        }

    }
}
