using System;
using System.Web.Mvc;
using Experiments.AspNetMvc3NewFeatures.Aspx.Controllers;
using Experiments.AspNetMvc3NewFeatures.Aspx.Models;

namespace Experiments.AspNetMvc3NewFeatures.Aspx
{
    public class MyControllerFactory : IControllerFactory
    {
        public IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            IController controller = null;

            if (controllerName == "favicon.ico")
                return null;

            if (controllerName == "Home")
            {
                controller = new HomeController(new ChartModel());
            }
            else
            {
                var controllerType = "Experiments.AspNetMvc3NewFeatures.Aspx.Controllers." + controllerName + "Controller";
                controller = Activator.CreateInstance(Type.GetType(controllerType)) as IController; 
            }


            if(controller == null)
                throw new ApplicationException("Cannot find controller");

            return controller;
        }

        public void ReleaseController(IController controller)
        {
            if (controller is IDisposable)
            {
                (controller as IDisposable).Dispose();
            }
        }
    }
}