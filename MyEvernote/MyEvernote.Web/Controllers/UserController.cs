using MyEvernote.BusinessLayer.Users;
using MyEvernote.DTO.Informing;
using MyEvernote.DTO.Response;
using MyEvernote.DTO.Users;
using System;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ShowProfile()
        {
            var model = Common.Helper.UserHelper.CurrentUser;
            return PartialView("~/Views/User/_ShowProfilePartial.cshtml", model);
        }
        [HttpPost]
        public ActionResult EditProfile()
        {
            return View();
        }

        public ActionResult ActivedProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActivedProfile(InsertUserDto dto)
        {
            //TODO:Gülsüm burada activedguid var mı kontrolü koy
            ResponseMessage<InsertUserDto> result = _userService.ValidateForActivedProfile(dto.ActivedGuid);
            try
            {
                string filename = string.Empty;

                if (result.IsSuccess)
                {
                    if (dto.ProfilImage != null)
                    {
                        if (dto.ProfilImage.ContentType == "image/jpeg" || dto.ProfilImage.ContentType == "image/jpg" || dto.ProfilImage.ContentType == "image/png")
                        {
                            filename = string.Format("user_{0}.{1}", dto.ActivedGuid, dto.ProfilImage.ContentType.Split('/')[1]);
                            dto.ProfilImage.SaveAs(Server.MapPath($"~/assets/Images/{filename}"));

                            dto.ImagePath = filename;

                            result.Messages.Clear();
                            result = _userService.ActivedUser(dto);
                        }
                        else
                        {
                            result.Messages.Clear();
                            result.IsSuccess = false;
                            result.Messages.Add("Yüklenen resmin uzantısı .png,.jpg ya da .jpeg olmalıdır!");
                        }
                    }
                    else
                    {
                        result.Messages.Clear();
                        result.IsSuccess = false;
                        result.Messages.Add("Profil resmi boş olamaz!");
                    }
                }


            }
            catch (Exception ex)
            {
                result.Messages.Clear();
                result.IsSuccess = false;
                result.Messages.Add("İşlem sırasında beklenmedik bir hata oluştu!");
                Common.Helper.Utility.ReportError(ex);


            }
            TempData["model"] = result;
            return View();
        }
    }
}