using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.ExchangeCookies
{
    public partial class SecondPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (string item in Request.Cookies)
            {
                Literal.Text += Request.Cookies[item].Value + "<br/>";
            }
        }

        protected void button_Click(object sender, EventArgs e)
        {
            Response.AppendCookie(new HttpCookie(new Random().Next().ToString(), "Cookie Set from SecondPage.aspx"));
            Response.Redirect("index.aspx");
        }
    }
}