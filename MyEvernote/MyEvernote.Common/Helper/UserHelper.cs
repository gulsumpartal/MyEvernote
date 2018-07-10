using MyEvernote.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyEvernote.Common.Helper
{
    public class UserHelper
    {
        public static UserDto CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session["User"]==null)
                {
                    return null;
                }
                return (UserDto)HttpContext.Current.Session["User"];
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }
    }
}
