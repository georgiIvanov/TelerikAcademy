using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.ShowVisitorInformation
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label.Text = Request.UserAgent + "<br/>";
            Label.Text += Request.UserHostAddress.ToString().Trim();
        }
    }
}