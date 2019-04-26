using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class OwnerPetBusinessResponse
    {
        public IEnumerable<OwnerPetBO> lstOwnerPetBO { get; set; }
        public HttpWebResponse oWebResponse { get; set; }
    }
}
