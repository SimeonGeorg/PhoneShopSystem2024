using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PhoneCatalog.Core.Models.Performance;
using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Core.Services;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Services.Tests
{
    [TestFixture]
    public class PhoneServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private PhoneService _phoneService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _phoneService = new PhoneService(_mockRepository.Object);
        }

        [Test]
        public async Task AllPhonesAsync_Returns_AllPhones()
        {
            // Arrange
            var phones = new List<Phone>
            {
                new Phone { Id = 1, Brand = "Brand1", Model = "Model1", ImageUrl = "Image1.jpg" },
                new Phone { Id = 2, Brand = "Brand2", Model = "Model2", ImageUrl = "Image2.jpg" }
            };
            _mockRepository.Setup(r => r.AllNoTracking<Phone>()).Returns(phones.AsQueryable());

            // Act
            var result = await _phoneService.AllPhonesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(phones.Count, result.Count());

            // Compare each phone in the result with the corresponding phone in the original list
            for (int i = 0; i < phones.Count; i++)
            {
                Assert.AreEqual(phones[i].Id, result.ElementAt(i).Id);
                Assert.AreEqual(phones[i].Brand, result.ElementAt(i).Brand);
                Assert.AreEqual(phones[i].Model, result.ElementAt(i).Model);
                Assert.AreEqual(phones[i].ImageUrl, result.ElementAt(i).ImageUrl);
            }
        }

        [Test]
        public async Task AllPhonesAsync_Returns_EmptyList_When_NoPhonesFound()
        {
            // Arrange
            var phones = new List<Phone>();
            _mockRepository.Setup(r => r.AllNoTracking<Phone>()).Returns(phones.AsQueryable());

            // Act
            var result = await _phoneService.AllPhonesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsEmpty(result);
        }
        [Test]
        public async Task AllPhonesByOwnerIdAsync_Returns_Phones_By_Owner_Id()
        {
            // Arrange
            int ownerId = 1;
            var phones = new List<Phone>
            {
                new Phone { Id = 1, Brand = "Brand1", Model = "Model1", ImageUrl = "Image1.jpg", OwnerId = ownerId },
                new Phone { Id = 2, Brand = "Brand2", Model = "Model2", ImageUrl = "Image2.jpg", OwnerId = ownerId }
            };
            _mockRepository.Setup(r => r.AllNoTracking<Phone>())
                .Returns(phones.AsQueryable());

            // Act
            var result = await _phoneService.AllPhonesByOwnerIdAsync(ownerId);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(phones.Count, result.Count());

            // Compare each phone in the result with the corresponding phone in the original list
            for (int i = 0; i < phones.Count; i++)
            {
                Assert.AreEqual(phones[i].Id, result.ElementAt(i).Id);
                Assert.AreEqual(phones[i].Brand, result.ElementAt(i).Brand);
                Assert.AreEqual(phones[i].Model, result.ElementAt(i).Model);
                Assert.AreEqual(phones[i].ImageUrl, result.ElementAt(i).ImageUrl);
                Assert.AreEqual(phones[i].Price, result.ElementAt(i).Price);
            }
        }

        [Test]
        public async Task AllPhonesByOwnerIdAsync_Returns_EmptyList_When_NoPhonesFound()
        {
            // Arrange
            int ownerId = 1;
            var phones = new List<Phone>();
            _mockRepository.Setup(r => r.AllNoTracking<Phone>())
                .Returns(phones.AsQueryable());

            // Act
            var result = await _phoneService.AllPhonesByOwnerIdAsync(ownerId);

            // Assert
            Assert.NotNull(result);
            Assert.IsEmpty(result);
        }
        [Test]
        public async Task ExistsAsync_Returns_True_If_Phone_Exists()
        {
            // Arrange
            int phoneId = 1;
            var phones = new[]
            {
                new Phone { Id = 1 },
                new Phone { Id = 2 },
                new Phone { Id = 3 }
            }.AsQueryable();

            _mockRepository.Setup(r => r.AllNoTracking<Phone>()).Returns(phones);

            // Act
            bool result = await _phoneService.ExistsAsync(phoneId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsAsync_Returns_False_If_Phone_Does_Not_Exist()
        {
            // Arrange
            int phoneId = 4; // Assuming phone with ID 4 does not exist
            var phones = new[]
            {
                new Phone { Id = 1 },
                new Phone { Id = 2 },
                new Phone { Id = 3 }
            }.AsQueryable();

            _mockRepository.Setup(r => r.AllNoTracking<Phone>()).Returns(phones);

            // Act
            bool result = await _phoneService.ExistsAsync(phoneId);

            // Assert
            Assert.IsFalse(result);
        }
        [Test]
        public async Task CreateAsync_Creates_New_Phone_And_Returns_Id()
        {
            // Arrange
            var model = new PhoneAddModel
            {
                Brand = "TestBrand",
                Model = "TestModel",
                CategoryId = 1, // Assuming category ID
                ImageUrl = "test.jpg"
            };
            int ownerId = 1; // Assuming owner ID

            var phone = new Phone
            {
                Id = 1,
                Brand = model.Brand,
                Model = model.Model,
                Price = model.CategoryId,
                ImageUrl = model.ImageUrl,
                CategoryId = model.CategoryId,
                OwnerId = ownerId
            };

            _mockRepository.Setup(r => r.AddAsync(It.IsAny<Phone>())).Callback<Phone>(p => phone = p);
            _mockRepository.Setup(r => r.SaveChangesAsync()).Returns(Task.FromResult(1));

            // Act
            var result = await _phoneService.CreateAsync(model, ownerId);

            // Assert
            Assert.That(model.Brand, Is.EqualTo(phone.Brand));
            Assert.That(model.Model, Is.EqualTo(phone.Model));
            Assert.That(model.CategoryId, Is.EqualTo(phone.Price));
            Assert.That(model.ImageUrl, Is.EqualTo(phone.ImageUrl));
            Assert.That(model.CategoryId, Is.EqualTo(phone.CategoryId));
            Assert.That(ownerId, Is.EqualTo(phone.OwnerId));
            Assert.That(phone.Id, Is.EqualTo(result));
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Phone>()), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
        [Test]
        public async Task EditAsync_Updates_Phone_And_Performance()
        {
            // Arrange
            int phoneId = 1;
            var model = new PhoneEditFormModel
            {
                Brand = "UpdatedBrand",
                Model = "UpdatedModel",
                Price = 1000,
                ImageUrl = "updated.jpg",
                CategoryId = 2, // Assuming category ID
               
            };
            model.Performances = new PerformanceEditFormModel
            {
                Id = 1,
                Processor = "UpdatedProcessor",
                Battery = "5000",
                CameraPxl = "64",
                Storage = "256",
                Ram = "8"
            };

            var phone = new Phone
            {
                Id = phoneId,
                Brand = "InitialBrand",
                Model = "InitialModel",
                Price = 500,
                ImageUrl = "initial.jpg",
                CategoryId = 1, // Assuming category ID
                OwnerId = 1 // Assuming owner ID
            };

            var performance = new Performance
            {
                Id = model.Performances.Id,
                Processor = "InitialProcessor",
                Battery = "4000",
                CameraPxl = "48pxl",
                Storage = "128 Storage",
                Ram = "6GB",
                PhoneId = phoneId
            };

            _mockRepository.Setup(r => r.GetByIdAsync<Phone>(phoneId)).ReturnsAsync(phone);
            _mockRepository.Setup(r => r.GetByIdAsync<Performance>(model.Performances.Id)).ReturnsAsync(performance);
            _mockRepository.Setup(r => r.SaveChangesAsync()).Returns(Task.FromResult(1));

            // Act
            await _phoneService.EditAsync(phoneId, model);

            // Assert
            Assert.That(phone.Brand, Is.EqualTo(model.Brand));
            Assert.That(phone.Model, Is.EqualTo(model.Model));
            Assert.That(phone.Price, Is.EqualTo(model.Price));
            Assert.That(phone.ImageUrl, Is.EqualTo(model.ImageUrl));
            Assert.That(phone.CategoryId, Is.EqualTo(model.CategoryId));

            Assert.That(performance.Processor, Is.EqualTo(model.Performances.Processor));
            Assert.That(performance.Battery, Is.EqualTo(model.Performances.Battery));
            Assert.That(performance.CameraPxl, Is.EqualTo(model.Performances.CameraPxl));
            Assert.That(performance.Storage, Is.EqualTo(model.Performances.Storage));
            Assert.That(performance.Ram, Is.EqualTo(model.Performances.Ram));

            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Exactly(2)); // Ensure SaveChangesAsync is called twice
        }

        [Test]
        public async Task DeleteAsync_Deletes_Phone()
        {
            // Arrange
            int phoneId = 1;

            _mockRepository.Setup(r => r.DeleteAsync<Phone>(phoneId)).Returns(Task.CompletedTask);
            _mockRepository.Setup(r => r.SaveChangesAsync()).Returns(Task.FromResult(1));

            // Act
            await _phoneService.DeleteAsync(phoneId);

            // Assert
            _mockRepository.Verify(r => r.DeleteAsync<Phone>(phoneId), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
