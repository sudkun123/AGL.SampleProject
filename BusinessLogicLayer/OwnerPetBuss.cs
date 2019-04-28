using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;
using DataObjects;
using System.Threading;

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

        public OwnerPetBusinessResponse getOwnerPetInfoByPetTypeBL(string petType)
        {
            objOwnerPetResponse = _iOwnerPetResponse.getOwnerPetInfoDA();

            return new OwnerPetBusinessResponse()
            {
                lstOwnerPetBO = (objOwnerPetResponse.lstOwnerPetDO != null) ?
                                commonEntityBLTransform(objOwnerPetResponse.lstOwnerPetDO, petType) : null,
                oWebResponse = objOwnerPetResponse.oWebResponse
            };
        }

        public PetListGroupByOwnerGenderBusinessResponse getOwnerPetInfoGroupByOwnerGenderBL(string petType)
        {
            objOwnerPetResponse = _iOwnerPetResponse.getOwnerPetInfoDA();

            return new PetListGroupByOwnerGenderBusinessResponse()
            {
                lstOwnerPetBO = (objOwnerPetResponse.lstOwnerPetDO != null) ?
                                getOwnerPetInfoGroupByOwnerGenderBLTransform(objOwnerPetResponse.lstOwnerPetDO, petType) : null,
                oWebResponse = objOwnerPetResponse.oWebResponse
            };
        }

        private List<OwnerPetBO> commonEntityBLTransform(IEnumerable<OwnerPetDO> objOwnerPetDO, string petType)
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
                        pets = item.pets.Select(m => new PetBO
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

        private Dictionary<string, List<PetBO>> getOwnerPetInfoGroupByOwnerGenderBLTransform(IEnumerable<OwnerPetDO> objOwnerPetDO, string petType)
        {
            var lOwnerPetBO = commonEntityBLTransform(objOwnerPetDO, petType).AsEnumerable();

            var dOwnerPetBO = from x in lOwnerPetBO
                        where x.pets != null
                        group x by Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(x.gender) into g
                        select new
                        {
                            gender = g.Key,
                            pets = g.SelectMany(p => p.pets)
                            .Where(pt => pt.type.Equals(petType, StringComparison.InvariantCultureIgnoreCase))
                            .OrderBy(o => o.name)
                            .ToList(),
                        };

            return dOwnerPetBO.ToDictionary(x => x.gender, x => x.pets);
        }
    }
}
