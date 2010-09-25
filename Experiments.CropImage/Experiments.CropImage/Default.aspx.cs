using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web.UI;

namespace Experiments.CropImage
{
    public partial class Default : Page
    {
        protected void CropCommandClick(object sender, EventArgs e)
        {
            var x = int.Parse(_xField.Value);
            var y = int.Parse(_yField.Value);
            var width = int.Parse(_widthField.Value);
            var height = int.Parse(_heightField.Value);

            using (var photo = Image.FromFile(Server.MapPath("~/Images/akropolis-doggie.jpg")))
            using (var result = new Bitmap(width, height, photo.PixelFormat))
            {
                result.SetResolution(
                        photo.HorizontalResolution,
                        photo.VerticalResolution);

                using (var g = Graphics.FromImage(result))
                {
                    g.InterpolationMode =
                         InterpolationMode.HighQualityBicubic;
                    g.DrawImage(photo,
                         new Rectangle(0, 0, width, height),
                         new Rectangle(x, y, width, height),
                         GraphicsUnit.Pixel);
                    photo.Dispose();

                    result.Save(Server.MapPath("~/Images/cropped_doggie.jpg"));
                }
            }
        }
    }
}