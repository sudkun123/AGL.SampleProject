using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PresentationLayer;
using PresentationLayer.Controllers;
using BusinessLogicLayer;

namespace PresentationLayer.Tests.Controllers
{
    [TestClass]
    class OwnerPetControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            OwnerPetController controller = new OwnerPetController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
