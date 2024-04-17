using Moq;
using NUnit.Framework;
using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Services;
using PhoneCatalog.Infrastructure.Data.Common;
using PhoneCatalog.Infrastructure.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneCatalog.Core.Services.Tests
{
    [TestFixture]
    public class CommentServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private CommentService _commentService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository>();
            _commentService = new CommentService(_mockRepository.Object);
        }

        [Test]
        public async Task AllCommentByOwnerId_Returns_Comments_By_OwnerId()
        {
            // Arrange
            int ownerId = 1;
            var comments = new List<Comment>
            {
                new Comment { Id = 1, CommentText = "Comment 1", OwnerId = ownerId, PhoneId = 1 },
                new Comment { Id = 2, CommentText = "Comment 2", OwnerId = ownerId, PhoneId = 2 }
            };
            _mockRepository.Setup(r => r.AllNoTracking<Comment>()).Returns(comments.AsQueryable());

            // Act
            var result = await _commentService.AllCommentByOwnerId(ownerId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(comments.Count));
            foreach (var comment in comments)
            {
                Assert.IsTrue(result.Any(c => c.Id == comment.Id && c.CommentText == comment.CommentText && c.OwnerId == comment.OwnerId && c.PhoneId == comment.PhoneId));
            }
        }

        [Test]
        public async Task AllCommentByUserId_Returns_Comments_By_UserId()
        {
            // Arrange
            string userId = "user1";
            var comments = new List<Comment>
            {
                new Comment { Id = 1, CommentText = "Comment 1", OwnerId = 1, PhoneId = 1, Owner = new Owner { UserId = userId } },
                new Comment { Id = 2, CommentText = "Comment 2", OwnerId = 2, PhoneId = 2, Owner = new Owner { UserId = userId } }
            };
            _mockRepository.Setup(r => r.AllNoTracking<Comment>()).Returns(comments.AsQueryable());

            // Act
            var result = await _commentService.AllCommentByUserId(userId);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(comments.Count));
            foreach (var comment in comments)
            {
                Assert.IsTrue(result.Any(c => c.CommentText == comment.CommentText && c.OwnerId == comment.OwnerId && c.PhoneId == comment.PhoneId));
            }
        }

        [Test]
        public async Task CreateAsync_Creates_New_Comment_And_Returns_Id()
        {
            // Arrange
            var model = new CommentAddModel { Id = 1, CommentText = "New comment", OwnerId = 1, PhoneId = 1 };
            int expectedCommentId = 1;
            _mockRepository.Setup(r => r.AddAsync(It.IsAny<Comment>())).Returns(Task.CompletedTask);
            _mockRepository.Setup(r => r.SaveChangesAsync()).Returns(Task.FromResult(0));

            // Act
            var result = await _commentService.CreateAsync(model);

            // Assert
            Assert.That(result, Is.EqualTo(expectedCommentId));
        }
        [Test]
        public async Task EditAsync_Updates_Comment()
        {
            // Arrange
            int commentId = 1;
            var model = new CommentAddModel
            {
                OwnerId = 123,
                CommentText = "Updated comment text",
                PhoneId = 123
            };

            var comment = new Comment
            {
                Id = commentId,
                OwnerId = 123,
                CommentText = "Old comment text",
                PhoneId = 456
            };

            _mockRepository.Setup(r => r.GetByIdAsync<Comment>(commentId)).ReturnsAsync(comment);
            _mockRepository.Setup(r => r.SaveChangesAsync()).ReturnsAsync(0);


            // Act
            await _commentService.EditAsync(commentId, model);

            // Assert
            Assert.That(comment.OwnerId, Is.EqualTo(model.OwnerId));
            Assert.That(comment.CommentText, Is.EqualTo(model.CommentText));
            Assert.That(comment.PhoneId, Is.EqualTo(model.PhoneId));
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}

