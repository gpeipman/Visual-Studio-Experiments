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

        public void GetImage(string horizontalFlip="", string verticalFlip="",
                            string rotateLeft="", string rotateRight="")
        {
            var imagePath = Server.MapPath("~/images/bunny-peanuts.jpg");
            var image = new WebImage(imagePath);

            if (!string.IsNullOrWhiteSpace(verticalFlip))
                image = image.FlipVertical();
            if (!string.IsNullOrWhiteSpace(horizontalFlip))
                image = image.FlipHorizontal();
            if (!string.IsNullOrWhiteSpace(rotateLeft))
                image = image.RotateLeft();
            if (!string.IsNullOrWhiteSpace(rotateRight))
                image = image.RotateRight();
            
            image.Write();
        }
    }
}
