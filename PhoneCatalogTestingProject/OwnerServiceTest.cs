using Moq;
using NUnit.Framework;
using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Services;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Services.Tests
{
    [TestFixture]
    public class OwnerServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private OwnerService _ownerService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _ownerService = new OwnerService(_mockRepository.Object);
        }

        [Test]
        public async Task IsExistByIdAsync_Returns_True_When_Owner_Exists()
        {
            // Arrange
            string userId = "user123";
            _mockRepository.Setup(r => r.All<Owner>()).Returns(new[]
            {
                new Owner { UserId = userId }
            }.AsQueryable());

            // Act
            bool result = await _ownerService.IsExistByIdAsync(userId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task IsExistByIdAsync_Returns_False_When_Owner_Does_Not_Exist()
        {
            // Arrange
            string userId = "user123";
            _mockRepository.Setup(r => r.All<Owner>()).Returns(Enumerable.Empty<Owner>().AsQueryable());

            // Act
            bool result = await _ownerService.IsExistByIdAsync(userId);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetOwnerIdAsync_Returns_OwnerId_IfExists()
        {
            // Arrange
            string userId = "user123";
            int ownerId = 1;
            _mockRepository.Setup(r => r.AllNoTracking<Owner>()).Returns(new[]
            {
                new Owner { Id = ownerId, UserId = userId }
            }.AsQueryable());

            // Act
            int? result = await _ownerService.GetOwnerIdAsync(userId);

            // Assert
            Assert.That(result, Is.EqualTo(ownerId));
        }

        [Test]
        public async Task GetOwnerIdAsync_Returns_Null_IfOwnerDoesNotExist()
        {
            // Arrange
            string userId = "user123";
            _mockRepository.Setup(r => r.AllNoTracking<Owner>()).Returns(Enumerable.Empty<Owner>().AsQueryable());

            // Act
            int? result = await _ownerService.GetOwnerIdAsync(userId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task CreateAsync_Adds_New_Owner()
        {
            // Arrange
            string userId = "user123";
            string phoneNumber = "1234567890";

            // Act
            await _ownerService.CreateAsync(userId, phoneNumber);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.Is<Owner>(o => o.UserId == userId && o.PhoneNumber == phoneNumber)), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
        [Test]
        public async Task OwnerWithPhoneNumberExistsAsync_Returns_True_When_Owner_Exists()
        {
            // Arrange
            string phoneNumber = "1234567890";
            _mockRepository.Setup(r => r.AllNoTracking<Owner>()).Returns(new[]
            {
                new Owner { PhoneNumber = phoneNumber }
            }.AsQueryable());

            // Act
            bool result = await _ownerService.OwnerWithPhoneNumberExistsAsync(phoneNumber);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task OwnerWithPhoneNumberExistsAsync_Returns_False_When_Owner_Does_Not_Exist()
        {
            // Arrange
            string phoneNumber = "1234567890";
            _mockRepository.Setup(r => r.AllNoTracking<Owner>()).Returns(Enumerable.Empty<Owner>().AsQueryable());

            // Act
            bool result = await _ownerService.OwnerWithPhoneNumberExistsAsync(phoneNumber);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetOwnerPersonalInfo_Returns_OwnerPersonalModel_IfExists()
        {
            // Arrange
            int ownerId = 1;
            string phoneNumber = "1234567890";
            string userId = "user123";
            _mockRepository.Setup(r => r.AllNoTracking<Owner>()).Returns(new[]
            {
                new Owner { Id = ownerId, PhoneNumber = phoneNumber, UserId = userId }
            }.AsQueryable());

            // Act
            var result = await _ownerService.GetOwnerPersonalInfo(ownerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(ownerId));
            Assert.That(result.PhoneNumber, Is.EqualTo(phoneNumber));
            Assert.That(result.UserId, Is.EqualTo(userId));
        }

        [Test]
        public async Task GetOwnerPersonalInfo_Returns_Null_IfOwnerDoesNotExist()
        {
            // Arrange
            int ownerId = 1;
            _mockRepository.Setup(r => r.AllNoTracking<Owner>()).Returns(Enumerable.Empty<Owner>().AsQueryable());

            // Act
            var result = await _ownerService.GetOwnerPersonalInfo(ownerId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddCommentToOwner_Adds_Comment_IfOwnerExists()
        {
            // Arrange
            int ownerId = 1;
            var commentModel = new CommentAddModel { Id = 1, CommentText = "Test Comment", PhoneId = 1, OwnerId = 1 };
            var owner = new Owner { Id = ownerId };
            _mockRepository.Setup(r => r.GetByIdAsync<Owner>(ownerId)).ReturnsAsync(owner);

            // Act
            await _ownerService.AddCommentToOwner(ownerId, commentModel);

            // Assert
            Assert.IsTrue(owner.Comments.Any(c => c.Id == commentModel.Id && c.CommentText == commentModel.CommentText && c.PhoneId == commentModel.PhoneId && c.OwnerId == commentModel.OwnerId));
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public void AddCommentToOwner_Throws_InvalidOperationException_IfOwnerDoesNotExist()
        {
            // Arrange
            int? ownerId = null;
            var commentModel = new CommentAddModel { Id = 1, CommentText = "Test Comment", PhoneId = 1, OwnerId = 1 };

            // Act & Assert
            Assert.ThrowsAsync<InvalidOperationException>(() => _ownerService.AddCommentToOwner(ownerId, commentModel));
        }
    }

}

