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
            if (LogOnException(_iOwnerPetBuss.getOwnerPetInfoGroupByOwnerGenderBL(petType).oWebResponse, petType) == null)
            {
                return View(_iOwnerPetBuss.getOwnerPetInfoGroupByOwnerGenderBL(petType).lstOwnerPetBO);
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