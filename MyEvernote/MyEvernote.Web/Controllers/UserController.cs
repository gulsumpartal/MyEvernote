using MyEvernote.BusinessLayer.Users;
using MyEvernote.DTO.Informing;
using MyEvernote.DTO.Users;
using System.Web;
using System.Web.Mvc;

namespace MyEvernote.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService ;
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
            var model =Common.Helper.UserHelper.CurrentUser;
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
        public PartialViewResult ActivedProfile(InsertUserDto dto,HttpPostedFileBase ProfilImagePath)
        {
            //TODO:Gülsüm burada activedguid var mı kontrolü koy
            var result = _userService.ValidateForActivedProfile(dto.ActivedGuid);
            if (!result.IsSuccess)
            {
                var model = new ErrorNotify
                {
                    Items = result.Messages,
                    RedirectingUrl = "/Auth/Login"
                };
                return PartialView("~/Views/Shared/_Error.cshtml", model);
            }
            
            if (ProfilImagePath != null)
            {
                if (ProfilImagePath.ContentType=="image/jpeg"|| ProfilImagePath.ContentType=="image/jpg" || ProfilImagePath.ContentType=="image/png")
                {
                    string filename = string.Format("user_{0}.{1}", dto.ActivedGuid, ProfilImagePath.ContentType.Split('/')[1]);
                    ProfilImagePath.SaveAs(Server.MapPath($"~/assets/Images/{filename}"));
                    dto.ProfilImagePath = filename;
                }
            }
            return PartialView("~/Views/Shared/_Error.cshtml");
        }
    }
}