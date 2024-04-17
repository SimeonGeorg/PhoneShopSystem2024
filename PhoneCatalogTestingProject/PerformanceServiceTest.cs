using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Core.Models.Performance;
using PhoneCatalog.Core.Services;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Services.Tests
{
    [TestFixture]
    public class PerformanceServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private PerformanceService _performanceService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _performanceService = new PerformanceService(_mockRepository.Object);
        }

        [Test]
        public async Task CreateAsync_Creates_Performance_And_Returns_Id()
        {
            // Arrange
            var model = new PhoneAddModel
            {
                Performances = new PerformanceDetailsFormModel
                {
                    Id =  1,  
                    Processor = "TestProcessor",
                    Ram = "TestRam",
                    Storage = "TestStorage",
                    CameraPxl = "TestCameraPxl",
                    Battery = "TestBattery"
                }
            };
            var phoneId = 1; 
            var expectedPerformanceId = 1; 

            _mockRepository.Setup(r => r.AddAsync(It.IsAny<Performance>())).Returns(Task.CompletedTask);
            _mockRepository.Setup(r => r.SaveChangesAsync()).Returns(Task.FromResult(1)); 


            // Act
            var result = await _performanceService.CreateAsync(model, phoneId);

            // Assert
            Assert.That(result, Is.EqualTo(expectedPerformanceId));
        }

        [Test]
        public async Task GetPerformancesByPhoneId_Returns_PerformanceEditFormModel()
        {
            // Arrange
            int phoneId = 1; // Provide a valid phone ID for testing
            var performances = new List<Performance>
    {
        new Performance { Id = 1, PhoneId = phoneId, Processor = "Processor1", Ram = "4", Battery = "Battery1", CameraPxl = "12", Storage = "128" },
        new Performance { Id = 2, PhoneId = phoneId, Processor = "Processor2", Ram = "8", Battery = "Battery2", CameraPxl = "16", Storage = "256" }
    };
            _mockRepository.Setup(r => r.AllNoTracking<Performance>()).Returns(performances.AsQueryable());

            // Act
            var result = await _performanceService.GetPerformancesByPhoneId(phoneId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(1)); // Assuming the first performance is returned
            Assert.That(result.Processor, Is.EqualTo("Processor1"));
            Assert.That(result.Ram, Is.EqualTo("4"));
            Assert.That(result.Battery, Is.EqualTo("Battery1"));
            Assert.That(result.CameraPxl, Is.EqualTo("12"));
            Assert.That(result.Storage, Is.EqualTo("128"));
            Assert.That(result.PhoneId, Is.EqualTo(phoneId));
        }

        [Test]
        public async Task GetPerformancesByPhoneIdForDelete_Returns_PerformanceDetailsModel()
        {
            // Arrange
            int phoneId = 1; // Provide a valid phone ID for testing
            var performances = new List<Performance>
    {
        new Performance { Id = 1, PhoneId = phoneId, Processor = "Processor1", Ram = "4", Battery = "Battery1", CameraPxl = "12", Storage = "128" },
        new Performance { Id = 2, PhoneId = phoneId, Processor = "Processor2", Ram = "8", Battery = "Battery2", CameraPxl = "16", Storage = "256" }
    };
            _mockRepository.Setup(r => r.AllNoTracking<Performance>()).Returns(performances.AsQueryable());

            // Act
            var result = await _performanceService.GetPerformancesByPhoneIdForDelete(phoneId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(1)); // Assuming the first performance is returned
            Assert.That(result.Processor, Is.EqualTo("Processor1"));
            Assert.That(result.Ram, Is.EqualTo("4"));
            Assert.That(result.Battery, Is.EqualTo("Battery1"));
            Assert.That(result.CameraPxl, Is.EqualTo("12"));
            Assert.That(result.Storage, Is.EqualTo("128"));
            Assert.That(result.PhoneId, Is.EqualTo(phoneId));
        }
    }
}
