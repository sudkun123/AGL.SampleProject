using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLayer
{
    public class MyAuthentication
    {
        public static bool isValidUser(string username, string password)
        {
            if (username == "admin" && password == "admin")
                return true;
            else
                return false;
        }
    }
}
