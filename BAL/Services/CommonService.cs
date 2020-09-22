using BAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BAL.Services
{
    public class CommonService
    {
        public UserModel GetUserInfo()
        {
            if (HttpContext.Current.Session["UserInfo"] == null)
                return null;
            else
                return HttpContext.Current.Session["UserInfo"] as UserModel;
        }

    }
}
