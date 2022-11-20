using CMS.Core.Constants;
using CMS.Core.Dtos;
using CMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CMS.Web.Controllers
{
    public class UserController : BaseController
    {


        public UserController(IUserService userService) : base(userService)
        {
        }
        [HttpGet]
        public IActionResult Index()
        {
            _userService.g();
            return View();
        }

        public async Task<JsonResult> GetUserData(Pagination pagination , Query query)
        {
            var result = await _userService.GetAll(pagination, query);
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
               await _userService.Create(input);
                return Ok(Results.AddSuccessResult()); 
            }
            return View();
        }

         [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = await _userService.Get(id);

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateUserDto input)
        {
            if (ModelState.IsValid)
            {
                await _userService.Update(input);
                return Ok(Results.EditSuccessResult());

            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.Delete(id);

            return Ok(Results.DeleteSuccessResult());

        }
        //[HttpGet]
        //public IActionResult ExportToExel()
        //{
        //    return View();
        //}
    }
    }
