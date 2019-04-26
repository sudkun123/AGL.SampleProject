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

        public ActionResult Index(string petType = "Cat")
        {
            if (LogOnException(_iOwnerPetBuss.getOwnerPetInfoByPetTypeBL(petType).oWebResponse, petType) == null)
            {
                IEnumerable<OwnerPetBO> lOwnerPetBO = _iOwnerPetBuss.getOwnerPetInfoByPetTypeBL(petType).lstOwnerPetBO;
                return View(lOwnerPetBO);
            }
            else
                return null;
        }

        private ActionResult LogOnException(HttpWebResponse oWebResponse, string petType)
        {
            if (_iOwnerPetBuss.getOwnerPetInfoByPetTypeBL(petType).oWebResponse != null)
                return Content(_iOwnerPetBuss.getOwnerPetInfoByPetTypeBL(petType).oWebResponse.StatusCode.ToString(), _iOwnerPetBuss.getOwnerPetInfoByPetTypeBL(petType).oWebResponse.StatusDescription);
            else
                return null;
        }
    }
}