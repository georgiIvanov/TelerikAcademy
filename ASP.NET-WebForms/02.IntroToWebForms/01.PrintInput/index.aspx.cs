using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.PrintInput
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBox1.Text))
            {
                hello_label.Visible = true;
                hello_label.Text = "Hello " + TextBox1.Text;
            }
        }
    }
}