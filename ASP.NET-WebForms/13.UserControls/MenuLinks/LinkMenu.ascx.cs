using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MenuLinks
{
    [System.ComponentModel.DefaultBindingProperty("DataSource")]
    public partial class LinkMenu : System.Web.UI.UserControl
    {
        public LinkMenu()
        {
            this.FontFamily = "Segoe UI";
            this.FontColor = "blue";
        }

        public string FontFamily { get; set; }

        public string FontColor { get; set; }

        public IEnumerable<MenuOption> DataSource
        {
            get { return (IEnumerable<MenuOption>)MenuList.DataSource; }
            set 
            {
                foreach (var item in value)
                {
                    if (string.IsNullOrWhiteSpace(item.FontColor))
                    {
                        item.FontColor = this.FontColor;
                    }
                }
                MenuList.DataSource = value; 
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            MenuList.Style.Add("font-family", this.FontFamily);
        }

        public override void DataBind()
        {
            MenuList.DataBind();

            base.DataBind();
        }
    }
}