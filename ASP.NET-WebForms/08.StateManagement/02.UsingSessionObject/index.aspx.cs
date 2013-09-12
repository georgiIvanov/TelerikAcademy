using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.UsingSessionObject
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["values"] == null)
            {
                Session.Add("values", new List<string>());
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            var list = (List<string>)Session["values"];
            list.Add(TextBox.Text);
            Label.Text = "";
            foreach (var item in list)
            {
                Label.Text += "<br/>" + item;
            }

            TextBox.Text = "";
        }
    }
}