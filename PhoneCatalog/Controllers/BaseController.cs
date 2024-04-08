using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PhoneCatalog.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
      
    }
}
