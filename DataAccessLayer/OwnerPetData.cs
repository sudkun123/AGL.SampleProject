using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
    public class OwnerPetData : IOwnerPetData
    {
        private const string URL = UtilitiesLayer.WebUtilities.URL;
        private const string httpVerb = UtilitiesLayer.WebUtilities.httpVerb;
        private const string contentType = UtilitiesLayer.WebUtilities.contentType;

        public OwnerPetResponse getOwnerPetInfoDA()
        {
            DataContainer oDataContainer = DataSupplier.MakeRequest(URL, "", httpVerb, contentType, typeof(List<OwnerPetDO>));
            return new OwnerPetResponse()
            {
                lstOwnerPetDO = (IEnumerable<OwnerPetDO>)oDataContainer.Data,
                oWebResponse = (HttpWebResponse)oDataContainer.errorData
            };
        }
    }


}
