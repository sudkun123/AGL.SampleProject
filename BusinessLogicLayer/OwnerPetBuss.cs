using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using DataObjects;

namespace BusinessLogicLayer
{
    public class OwnerPetBuss : IOwnerPetBuss
    {
        private IOwnerPetData _iOwnerPetResponse;
        OwnerPetResponse objOwnerPetResponse;

        public OwnerPetBuss(IOwnerPetData iOwnerPetResponse)
        {
            _iOwnerPetResponse = iOwnerPetResponse;
        }

        public OwnerPetBusinessResponse getOwnerPetInfoBL()
        {
            objOwnerPetResponse = _iOwnerPetResponse.getOwnerPetInfoDA();

            return new OwnerPetBusinessResponse()
            {
                lstOwnerPetBO = (objOwnerPetResponse.lstOwnerPetDO != null) ? TransformIntoBusinessObject(objOwnerPetResponse.lstOwnerPetDO) : null,
                oWebResponse = objOwnerPetResponse.oWebResponse
            };
        }

        private List<OwnerPetBO> TransformIntoBusinessObject(IEnumerable<OwnerPetDO> objOwnerPetDO)
        {
            List<OwnerPetBO> lstOwnerPetBO = new List<OwnerPetBO>();
            OwnerPetBO objOwnerPetBO;

            foreach (var item in objOwnerPetDO)
            {
                if (item.pets != null)
                {
                    objOwnerPetBO = new OwnerPetBO
                    {
                        age = item.age,
                        gender = item.gender,
                        name = item.name,
                        pets = item.pets.Where(x => x.type == "Cat").Select(m => new PetBO
                        {
                            name = m.name,
                            type = m.type
                        }).ToList()
                    };

                    lstOwnerPetBO.Add(objOwnerPetBO);
                }
            }

            return lstOwnerPetBO;
        }
    }
}
