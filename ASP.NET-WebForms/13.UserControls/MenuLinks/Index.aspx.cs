using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuLinks
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuOption[] options = { new MenuOption("lol", "this-page.aspx"), 
                                       new MenuOption("no", "gets-you.aspx"),
                                       new MenuOption("rofl", "nowhere.aspx"),
                                       new MenuOption("copter", "haha.aspx") };

            LinkMenu.FontFamily = "Consolas";
            LinkMenu.FontColor = "#FF6600";
            LinkMenu.DataSource = options;
            LinkMenu.DataBind();
        }
    }
}