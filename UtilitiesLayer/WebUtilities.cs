using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLayer
{

    public static class WebUtilities
    {
        public const string URL = "http://agl-developer-test.azurewebsites.net/people.json1";
        public const string httpVerb = "GET";
        public const string contentType = "application/json";

        //IMPLEMENT SINGLETON

        //private static readonly WebUtilities instance = new WebUtilities();
        //private enum httpVerb {
        //    GET = 1, POST = 2, PUT = 3, DELETE = 4 
        //}
        //// Explicit static constructor to tell C# compiler
        //// not to mark type as beforefieldinit
        //static WebUtilities()
        //{
        //}

        //private WebUtilities()
        //{
        //}

        //public static WebUtilities Instance
        //{
        //    get
        //    {
        //        return instance;
        //    }
        //}
    }

    
}
