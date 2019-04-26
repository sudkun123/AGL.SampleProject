using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    [Serializable]
    public class OwnerPetResponse
    {
        public IEnumerable<OwnerPetDO> lstOwnerPetDO { get; set; }
        public HttpWebResponse oWebResponse { get; set; }
    }
}
