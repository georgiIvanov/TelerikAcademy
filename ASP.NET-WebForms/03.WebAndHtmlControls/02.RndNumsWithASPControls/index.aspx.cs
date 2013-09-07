using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.RndNumsWithASPControls
{
    public partial class index : System.Web.UI.Page
    {
        static Random rng = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_input_Click(object sender, EventArgs e)
        {
            var min = int.Parse(txt_firstNumber.Text);
            var max = int.Parse(txt_secondNumber.Text);

            lbl_output.Text = rng.Next(min, max + 1).ToString();
        }
    }
}