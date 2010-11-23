using System;
using System.Web.Mvc;
using Experiments.AspNetMvc3NewFeatures.Aspx.Controllers;
using Experiments.AspNetMvc3NewFeatures.Aspx.Models;
using System.Web.SessionState;
using System.Web.Routing;

namespace Experiments.AspNetMvc3NewFeatures.Aspx
{
    public class MyControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            IController controller;

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

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }
    }
}