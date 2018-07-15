using MyEvernote.BusinessLayer.Users;
using MyEvernote.Common.Service;
using MyEvernote.DTO.Informing;
using MyEvernote.DTO.Response;
using MyEvernote.DTO.Users;
using MyEvernote.Web.Helper;
using System.Collections.Generic;
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
            ResponseMessage<UserDto> response = _userService.GetUserDetails(dto.UserName, dto.Password);
            if (response.IsSuccess)
            {
                Common.Helper.UserHelper.CurrentUser = response.Result;
            }
            return Json(response);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Register(RegisterUserDto dto)
        {
            ResponseMessage<RegisterUserDto> result = _userService.AddUser(dto);
            if (result.IsSuccess)
            {
                result.Messages.Add(SendMailForActived(dto));
                var model = new SuccessNotify
                {
                    Items = result.Messages,
                    Title = "Kayıt İşlemi Başarılı!",
                    RedirectingUrl = "/Auth/Login"
                };
                return PartialView("~/Views/Shared/_SuccessPartial.cshtml", model);
            }

            else
            {
                var model = new ErrorNotify
                {
                    RedirectingUrl = "/Auth/Login"
                };
                if (result.Messages.Count > 0)
                {
                    model.Items = result.Messages;
                }
                else
                {
                    model.Items.Add("İşlem sırasında hata oluştu lütfen tekrar deneyiniz!");
                }
                return PartialView("~/Views/Shared/_Error.cshtml", model);
            }
        }

        private string SendMailForActived(RegisterUserDto dto)
        {
            string result = string.Empty;
            Dictionary<string, string> mailProp = new Dictionary<string, string>();
            mailProp.Add("baseUrl", Utility.BaseUrl);
            mailProp.Add("username", dto.Username);
            mailProp.Add("keyValue", _userService.GetActivedGuid(dto.Username, dto.Password).ToString());
            if (MailService.SendMail(dto.Email, MailService.MailTemplateKeys.ActivedAccountTemplate, mailProp))
                result = "Kullanıcı Profil Bilgilerini Doldurmak İçin Mailinizi Kontrol Ediniz!";
            else
                result = "Kullanıcı Bilgileri Başarılı ile Kayıt Edilmiştir. Profil Aktivasyon mail gönderimi sırasında hata oluşmuştur. Lütfen sistem yöneticiniz ile iletişime geçiniz!";
            return result;
        }

        [HttpPost]
        public JsonResult Logout()
        {
            Common.Helper.UserHelper.CurrentUser = null;

            return Json("OK");
        }

    }
}