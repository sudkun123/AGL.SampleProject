using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BusinessLogicLayer;
using BusinessObjects;
using log4net;
using PresentationLayer.CustomFilters;
using System.Threading;

namespace PresentationLayer.Controllers
{
    public class OwnerPetController : Controller
    {
        private IOwnerPetBuss _iOwnerPetBuss;

        public OwnerPetController()
        {
            _iOwnerPetBuss = new OwnerPetBuss();
        }

        public OwnerPetController(IOwnerPetBuss iOwnerPetBuss)
        {
            _iOwnerPetBuss = iOwnerPetBuss;
        }

        [PresentationLogger]
        [MyAuthentication]
        [HttpGet]

        public ActionResult Index(string petType = "Cat")
        {
            var result = _iOwnerPetBuss.getOwnerPetInfoGroupByOwnerGenderBL(petType);

            if (result == null || (result.oWebResponse == null && result.lstOwnerPetBO == null))
                return Content(HttpStatusCode.BadGateway.ToString());
            else if (result.oWebResponse != null)
                return Content(result.oWebResponse.StatusCode.ToString(), result.oWebResponse.StatusDescription);
            else if (result.lstOwnerPetBO == null)
                return Content(HttpStatusCode.BadRequest.ToString());
            else if ((result.lstOwnerPetBO.Where(x => x.Key == "Male").FirstOrDefault()).Value.Count == 0 
                                || (result.lstOwnerPetBO.Where(x => x.Key == "Female").FirstOrDefault()).Value.Count == 0)
                return Content(HttpStatusCode.NotFound.ToString(), "No" + petType + " found!");
            else 
                return View(result.lstOwnerPetBO);
        }
    }
}