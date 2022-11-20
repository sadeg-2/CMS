using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
