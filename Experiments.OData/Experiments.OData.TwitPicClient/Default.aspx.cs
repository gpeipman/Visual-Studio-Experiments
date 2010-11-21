using System;
using System.Linq;
using System.Web.UI;

namespace Experiments.OData.TwitPicClient
{
    public partial class Default : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            var uri = new Uri("http://odata.twitpic.com/");
            
            var user = Request.QueryString["user"];
            if (string.IsNullOrWhiteSpace(user))
            {
                user = "gpeipman";
            }

            var client = new TwitpicData.TwitpicData(uri);
            client.IgnoreMissingProperties = false;
            client.IgnoreResourceNotFoundException = false;

            var images =  from u in client.Users
                          from i in u.Images
                          where u.UserName == user                          
                          select i;

            if (!string.IsNullOrWhiteSpace(filterField.Text))
                images = from i in images
                         where i.Message.ToLower().Contains(filterField.Text.ToLower())
                         select i;

            images = images.OrderByDescending(i => i.Timestamp);

            picsByLabel.Text = user;
            imagesRepeater.DataSource = images.Take(10);
            imagesRepeater.DataBind();
        }
    }
}
