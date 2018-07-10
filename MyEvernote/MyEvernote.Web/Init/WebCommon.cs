using MyEvernote.Common.Helper;
using MyEvernote.Common.Inıt;

namespace MyEvernote.Web.Init
{
    public class WebCommon : ICommon
    {
        public string GetCurrentUserName()
        {
            string result = UserHelper.CurrentUser==null?"SYSTEM": UserHelper.CurrentUser.Username;
            return result;
        }
    }
}