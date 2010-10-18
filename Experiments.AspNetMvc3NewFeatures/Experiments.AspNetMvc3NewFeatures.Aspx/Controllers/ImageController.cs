using System.Web.Helpers;
using System.Web.Mvc;

namespace Experiments.AspNetMvc3NewFeatures.Aspx.Controllers
{
    public class ImageController : Controller
    {
        public string ImagePath
        {
            get
            {
                var server = ControllerContext.HttpContext.Server;
                var imagePath = server.MapPath("~/images/bunny-peanuts.jpg");
                return imagePath;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public void GetImage()
        {
            new WebImage(ImagePath)
                .Write();
        }

        public ActionResult Cropped()
        {
            return View();
        }

        public void GetCropped()
        {
            new WebImage(ImagePath)
                .Crop(50, 50, 50, 50) // crop 50px from all sides
                .Write();
        }

        public ActionResult HorizontalFlip()
        {
            return View();
        }

        public void GetHorizontalFlip()
        {
            new WebImage(ImagePath)
                .FlipHorizontal()
                .Write();
        }

        public ActionResult VerticalFlip()
        {
            return View();
        }

        public void GetVerticalFlip()
        {
            new WebImage(ImagePath)
                .FlipVertical()
                .Write();
        }

        public ActionResult Resized()
        {
            return View();
        }

        public void GetResized()
        {
            new WebImage(ImagePath)
                .Resize(200, 200) // resize image to 200x200 px
                .Write();
        }

        public ActionResult RotateLeft()
        {
            return View();
        }

        public void GetRotateLeft()
        {
            new WebImage(ImagePath)
                .RotateLeft()
                .Write();
        }

        public ActionResult RotateRight()
        {
            return View();
        }

        public void GetRotateRight()
        {
            new WebImage(ImagePath)
                .RotateRight()
                .Write();
        }

        public ActionResult TextWatermark()
        {
            return View();
        }

        public void GetTextWatermark()
        {
            new WebImage(ImagePath)
                .AddTextWatermark("Watermark", "white",14,"Bold")
                .Write();
        }

        public ActionResult ImageWatermark()
        {
            return View();
        }

        public void GetImageWatermark()
        {
            var watermarkPath = HttpContext.Server.MapPath("~/images/watermark.png");
            var watermark = new WebImage(watermarkPath);

            new WebImage(ImagePath)
                .AddImageWatermark(watermark)
                .Write();
        }
    }
}
