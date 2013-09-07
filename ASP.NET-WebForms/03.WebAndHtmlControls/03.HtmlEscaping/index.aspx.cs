using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.HtmlEscaping
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            var text = Server.HtmlEncode(txt_inputTextbox.Text);
            

            txt_outputTextbox.Text = text;
            lbl_outputLabel.Text = text;
        }
    }
}