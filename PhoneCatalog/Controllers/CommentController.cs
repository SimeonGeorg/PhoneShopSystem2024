using Microsoft.AspNetCore.Mvc;
using PhoneCatalog.Core.Contracts;
using PhoneCatalog.Core.Models.Comment;
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
                
                return View(commentsModel);     
            }
            else
            {
                commentsModel = await commentService.AllCommentByUserId(userId);
            }
            return View(commentsModel);
        }
        [HttpGet]
        public async Task<IActionResult> PhoneComment(int phoneId,int ownerId)
        {
            var userId = User.Id();
            CommentPhoneDisplayModel commentsModel;
            

            if (await ownerService.IsExistByIdAsync(userId))
            {

                commentsModel = await commentService.GetPhoneCommentsModels(phoneId);
                commentsModel.Comments = await commentService.AllCommentsByPhoneId(phoneId);
                return View(commentsModel);
            }
            else
            {
                commentsModel = await commentService.GetPhoneCommentsModels(phoneId);
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
            

            return RedirectToAction(nameof(Mine), new { commentId,commentModel.PhoneId });
        }
    }
}
  
