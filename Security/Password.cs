using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace HotelManagement.Security
{
    public class Password
    {
        public static string Encrypt(String pass)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(pass, "SHA1");
        }
    }
}