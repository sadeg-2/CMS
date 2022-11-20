using CMS.Core.Constants;
using CMS.Core.Dtos;
using CMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    public class UserController : BaseController
    {

        private readonly IUserService _userServise;

        public UserController(IUserService userServise)
        {
            _userServise = userServise;
        }
        [HttpGet]
        public IActionResult Index()
        {
            _userServise.g();
            return View();
        }

        public async Task<JsonResult> GetUserData(Pagination pagination , Query query)
        {
            var result = await _userServise.GetAll(pagination, query);
            return Json(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateUserDto input)
        {
            if (ModelState.IsValid) { 
               await _userServise.Create(input);
                return Ok(Results.AddSuccessResult()); 
            }
            return View();
        }

         [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = await _userServise.Get(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateUserDto input)
        {
            if (ModelState.IsValid)
            {
                await _userServise.Update(input);
                return Ok(Results.EditSuccessResult());

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _userServise.Delete(id);

            return Ok(Results.DeleteSuccessResult());

        }
        //[HttpGet]
        //public IActionResult ExportToExel()
        //{
        //    return View();
        //}
    }
    }
