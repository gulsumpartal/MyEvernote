
using MyEvernote.BusinessLayer.Response;
using MyEvernote.BusinessLayer.Users;
using MyEvernote.Common.Helper;
using MyEvernote.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userService;
        public AuthController()
        {
            _userService = new UserService();
        }
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(LoginUserDto dto)
        {
              ResponseMessage<UserDto> response  = _userService.GetUserDetails(dto.UserName, dto.Password);
            if (response.IsSuccess)
            {
                UserHelper.CurrentUser = response.Result;
            }
                return Json(response);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(RegisterUserDto dto)
        {
            ResponseMessage<RegisterUserDto> response = _userService.AddUser(dto);

            return Json(response); ;
        }
        [HttpPost]
        public JsonResult Logout()
        {
            UserHelper.CurrentUser = null;

            return Json("OK");
        }
        
    }
}