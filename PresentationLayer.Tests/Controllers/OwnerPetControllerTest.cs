using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer;
using PresentationLayer.Controllers;
using BusinessLogicLayer;
using BusinessObjects;

namespace PresentationLayer.Tests.Controllers
{
    [TestClass()]
    public class OwnerPetControllerTest:Controller
    {
        public IOwnerPetBuss _iOwnerPetBuss;

        public OwnerPetControllerTest()
        {

        }

        public OwnerPetControllerTest(IOwnerPetBuss iOwnerPetBuss)
        {
            _iOwnerPetBuss = iOwnerPetBuss;
        }

        [TestMethod()]
        public void SuccessScenario()
        {
            var oOwnerPet = _iOwnerPetBuss.getOwnerPetInfoGroupByOwnerGenderBL("Cat").lstOwnerPetBO;

            Assert.IsTrue(oOwnerPet.Count == 2);
        }
        
    }
}
