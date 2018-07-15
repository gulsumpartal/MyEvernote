using System.Configuration;

namespace MyEvernote.Web.Helper
{
    public class Utility:Common.Helper.Utility
    {
        public static string BaseUrl 
        {
            get
            {
                return ConfigurationManager.AppSettings["BaseUrl"];
            }
        }
    }
}