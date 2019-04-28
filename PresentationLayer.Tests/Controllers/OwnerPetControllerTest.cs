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
    public class OwnerPetControllerTest : Controller
    {
        public OwnerPetControllerTest()
        {

        }

        [TestMethod()]
        public void SuccessScenarioWithCat()
        {
            var oOwnerPet = new OwnerPetController().Index("Cat") as ViewResult;
            if (oOwnerPet != null)
            {
                var result = ((Dictionary<string, List<PetBO>>)oOwnerPet.Model);
                Assert.IsTrue(result.Count == 2);
                Assert.IsTrue(result.Any(x => x.Key == "Male"));
                Assert.IsTrue((result.Where(x => x.Key == "Male").FirstOrDefault()).Value.Count == 4);
                Assert.IsTrue(result.Any(x => x.Key == "Female"));
                Assert.IsTrue((result.Where(x => x.Key == "Female").FirstOrDefault()).Value.Count == 3);
            }
            else
                Assert.IsTrue((((ContentResult)(new OwnerPetController().Index("Cat"))).Content).Equals("NotFound",StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod()]
        public void SuccessScenarioWithCatByDefaultParam()
        {
            var oOwnerPet = new OwnerPetController().Index("") as ViewResult;
            if (oOwnerPet != null)
            {
                var result = ((Dictionary<string, List<PetBO>>)oOwnerPet.Model);
                Assert.IsTrue(result.Count == 2);
                Assert.IsTrue(result.Any(x => x.Key == "Male"));
                Assert.IsTrue((result.Where(x => x.Key == "Male").FirstOrDefault()).Value.Count == 4);
                Assert.IsTrue(result.Any(x => x.Key == "Female"));
                Assert.IsTrue((result.Where(x => x.Key == "Female").FirstOrDefault()).Value.Count == 3);
            }
            else
                Assert.IsTrue((((ContentResult)(new OwnerPetController().Index("Cat"))).Content).Equals("NotFound", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod()]
        public void SuccessScenarioWithCatByNonProperCasing()
        {
            var oOwnerPet = new OwnerPetController().Index("cAT") as ViewResult;
            if (oOwnerPet != null)
            {
                var result = ((Dictionary<string, List<PetBO>>)oOwnerPet.Model);
                Assert.IsTrue(result.Count == 2);
                Assert.IsTrue(result.Any(x => x.Key == "Male"));
                Assert.IsTrue((result.Where(x => x.Key == "Male").FirstOrDefault()).Value.Count == 4);
                Assert.IsTrue(result.Any(x => x.Key == "Female"));
                Assert.IsTrue((result.Where(x => x.Key == "Female").FirstOrDefault()).Value.Count == 3);
            }
            else
                Assert.IsTrue((((ContentResult)(new OwnerPetController().Index("Cat"))).Content).Equals("NotFound", StringComparison.InvariantCultureIgnoreCase));
        }

        [TestMethod()]
        public void NotFoundScenarioWithPussyCat()
        {
            var oOwnerPet = new OwnerPetController().Index("Cat") as ViewResult;
            if (oOwnerPet != null)
            {
                var result = ((Dictionary<string, List<PetBO>>)oOwnerPet.Model);
                Assert.IsTrue((result.Where(x => x.Key == "Male").FirstOrDefault()).Value.Count == 0);
                Assert.IsTrue((result.Where(x => x.Key == "Female").FirstOrDefault()).Value.Count == 0);
            }
            else
                Assert.IsTrue((((ContentResult)(new OwnerPetController().Index("Cat"))).Content).Equals("NotFound", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
