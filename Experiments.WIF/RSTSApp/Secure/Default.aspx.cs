using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.IdentityModel.Claims;

namespace RSTSApp.Secure
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var identity = (IClaimsIdentity)User.Identity;
            Repeater1.DataSource = identity.Claims;
            Repeater1.DataBind();
        }
    }
}