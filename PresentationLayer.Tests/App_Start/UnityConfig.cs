using BusinessLogicLayer;
using DataAccessLayer;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace PresentationLayer.Tests
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IOwnerPetBuss, OwnerPetBuss>();
            container.RegisterType<IOwnerPetData, OwnerPetData>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}