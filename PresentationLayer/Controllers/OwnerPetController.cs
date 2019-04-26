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

namespace PresentationLayer.Controllers
{
    public class OwnerPetController : Controller
    {
        private IOwnerPetBuss _iOwnerPetBuss;

        public OwnerPetController()
        {
        }

        public OwnerPetController(IOwnerPetBuss iOwnerPetBuss)
        {
            _iOwnerPetBuss = iOwnerPetBuss;
        }

        [PresentationLogger]
        [MyAuthentication]
        [HttpGet]
        public ActionResult Index()
        {
            if (_iOwnerPetBuss.getOwnerPetInfoBL().oWebResponse != null)
            {
                switch (_iOwnerPetBuss.getOwnerPetInfoBL().oWebResponse.StatusCode)
                {
                    case HttpStatusCode.InternalServerError:
                        return Content(HttpStatusCode.InternalServerError.ToString(), _iOwnerPetBuss.getOwnerPetInfoBL().oWebResponse.StatusDescription);
                    case HttpStatusCode.NotFound:
                        return Content(HttpStatusCode.NotFound.ToString(), _iOwnerPetBuss.getOwnerPetInfoBL().oWebResponse.StatusDescription);
                    case HttpStatusCode.BadRequest:
                        return Content(HttpStatusCode.BadRequest.ToString(), _iOwnerPetBuss.getOwnerPetInfoBL().oWebResponse.StatusDescription);
                    case HttpStatusCode.Unauthorized:
                        return Content(HttpStatusCode.Unauthorized.ToString(), _iOwnerPetBuss.getOwnerPetInfoBL().oWebResponse.StatusDescription);
                }
            }

            IEnumerable<OwnerPetBO> lOwnerPetBO = _iOwnerPetBuss.getOwnerPetInfoBL().lstOwnerPetBO;

            return View(lOwnerPetBO);
        }
    }
}