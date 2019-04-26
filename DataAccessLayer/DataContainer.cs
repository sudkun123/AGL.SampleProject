using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataContainer
    {
        public object Data { get; set; }
        public WebResponse errorData { get; set; }
    }
}
