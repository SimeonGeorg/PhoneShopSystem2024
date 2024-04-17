using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
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
        private readonly IPhoneService phoneService;

        public CommentController(
            ICommentService _commentService,
            IOwnerService _ownerService,
            IPhoneService _phoneService)
        {
            commentService = _commentService;
            ownerService = _ownerService;
            phoneService = _phoneService;
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<CommentServiceModel> commentsModel;
         

            if (await ownerService.IsExistByIdAsync(userId))
            {
                var ownerId = await ownerService.GetOwnerIdAsync(userId) ?? 0;
                commentsModel = await commentService.GetMineComents(ownerId);
                var owner = await ownerService.GetOwnerPersonalInfo(ownerId);
                
                
                
                return View(commentsModel);     
            }
            else
            {
                commentsModel = await commentService.AllCommentByUserId(userId);
            }
            return View(commentsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int phoneId, int ownerId)
        {
            var commentModel = new CommentAddModel()
            {
                PhoneId = phoneId,
                OwnerId = ownerId
            };

            return View(commentModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentAddModel commentModel)
        {
            if (await phoneService.ExistsAsync(commentModel.PhoneId) == false)
            {
                ModelState.AddModelError(nameof(commentModel.PhoneId), "Phone does not exist");
            }

            if (ModelState.IsValid == false)
            {
                return View();
            }

            int? ownerId = await ownerService.GetOwnerIdAsync(User.Id());
            int commentId = await commentService.CreateAsync(commentModel);
            
                await ownerService.AddCommentToOwner(ownerId, commentModel);
            

            return RedirectToAction(nameof(Mine), new { commentId });
        }
    }
}
  
