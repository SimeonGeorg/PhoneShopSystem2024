using Microsoft.AspNetCore.Mvc;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models;
using PhoneCatalog.Core.Models.Comment;
using PhoneCatalog.Core.Models.Phone;
using PhoneCatalog.Core.Services;
using System.Security.Claims;

namespace PhoneCatalog.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        private readonly IOwnerService ownerService;

        public CommentController(
            ICommentService _commentService,
            IOwnerService _ownerService)
        {
            commentService = _commentService;
            ownerService = _ownerService;
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<CommentServiceModel> model;



            if (await ownerService.IsExistByIdAsync(userId))
            {
                int ownerId = await ownerService.GetOwnerIdAsync(userId) ?? 0;
                model = await commentService.AllCommentByOwnerId(ownerId);
                if (model != null)
                    return View(model);
            }
            else
            {
                model = await commentService.AllCommentByUserId(userId);
            }
            return View(model);
        }
    }
}
  
