using System.Web.Helpers;
using System.Web.Mvc;

namespace Experiments.AspNetMvc3NewFeatures.Aspx.Controllers
{
    public class ImageWorkshopController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public void GetImage(FormCollection items)
        {
            var imagePath = Server.MapPath("~/images/bunny-peanuts.jpg");
            var image = new WebImage(imagePath);

            if (!string.IsNullOrWhiteSpace(items["VerticalFlip"]))
                image = image.FlipVertical();
            if (!string.IsNullOrWhiteSpace(items["HorizontalFlip"]))
                image = image.FlipHorizontal();
            if (!string.IsNullOrWhiteSpace(items["RotateLeft"]))
                image = image.RotateLeft();
            if (!string.IsNullOrWhiteSpace(items["RotateRight"]))
                image = image.RotateRight();
            
            image.Write();
        }
    }
}
