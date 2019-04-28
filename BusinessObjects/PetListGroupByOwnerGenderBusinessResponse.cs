using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class PetListGroupByOwnerGenderBusinessResponse
    {
        public Dictionary<string, List<PetBO>> lstOwnerPetBO { get; set; }
        public HttpWebResponse oWebResponse { get; set; }
    }
}
