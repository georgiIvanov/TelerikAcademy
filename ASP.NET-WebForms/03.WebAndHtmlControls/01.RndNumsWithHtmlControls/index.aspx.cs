using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.RndNumsWithHtmlControls
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);
        }

        protected void submit_ServerClick(object sender, EventArgs e)
        {
            var lowerBound = int.Parse(input_first_number.Value);
            var upperBound = int.Parse(input_second_number.Value);

            outputLabel.InnerText = new Random().Next(lowerBound, upperBound + 1).ToString();

            
        }


    }
}