using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class OwnerPetBO
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public List<PetBO> pets { get; set; }
    }
}
