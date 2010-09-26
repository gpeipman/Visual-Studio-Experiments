using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;

namespace Experiments.ResizeImage
{
    public partial class Default : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ErrorLabel.Visible = false;
        }
        protected void CreateScaleThumbnailButtonClick(object sender, EventArgs e)
        {
            var path = Server.MapPath("~/images/original.jpg");
            if (!File.Exists(path))
            {
                ErrorLabel.Text = "Cannot find file original.jpg!";
                return;
            }

            var thumbPath  = Server.MapPath("~/images/original_thumb.jpg");
            if (File.Exists(thumbPath))
                File.Delete(thumbPath);

            using (var file = File.OpenRead(path))
            using (var thumbFile = File.Create(thumbPath))
                ResizeImage(0.1, file, thumbFile);
        }

        private static void ResizeImage(double scaleFactor, Stream fromStream, Stream toStream)
        {
            using (var image = Image.FromStream(fromStream))
            {
                var newWidth = (int) (image.Width*scaleFactor);
                var newHeight = (int) (image.Height*scaleFactor);

                using (var thumbnailBitmap = new Bitmap(newWidth, newHeight))
                using (var thumbnailGraph = Graphics.FromImage(thumbnailBitmap))
                {
                    thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                    thumbnailGraph.DrawImage(image, imageRectangle);

                    thumbnailBitmap.Save(toStream, image.RawFormat);
                }
            }
        }

        protected void CreateSquareThumbnailButtonClick(object sender, EventArgs e)
        {
            var path = Server.MapPath("~/images/original.jpg");
            if (!File.Exists(path))
            {
                ErrorLabel.Text = "Cannot find file original.jpg!";
                return;
            }

            var thumbPath = Server.MapPath("~/images/avatar.jpg");
            if (File.Exists(thumbPath))
                File.Delete(thumbPath);

            using (var file = File.OpenRead(path))
            using (var thumbFile = File.Create(thumbPath))
                CreateAvatar(100, file, thumbFile);            
        }

        public void CreateAvatar(int sideLength, Stream fromStream, Stream toStream)
        {
            using (var image = Image.FromStream(fromStream))
            using (var thumbBitmap = new Bitmap(sideLength, sideLength))
            {
                var a = Math.Min(image.Width, image.Height);
                var x = (image.Width - a) / 2;
                var y = (image.Height - a) / 2;

                using (var thumbGraph = Graphics.FromImage(thumbBitmap))
                {
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;

                    var imgRectangle = new Rectangle(0, 0, sideLength, sideLength);
                    thumbGraph.DrawImage(image, imgRectangle, x, y, a, a, GraphicsUnit.Pixel);
                    thumbBitmap.Save(toStream, ImageFormat.Png);
                }
            }
        }
    }
}
