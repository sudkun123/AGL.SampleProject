using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    [Serializable]
    public class OwnerPetDO
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public List<PetDO> pets { get; set; }
    }
}
