using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03.AjaxPhotoAlbum
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static AjaxControlToolkit.Slide[] GetSlides()
        {
            AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[4];

            imgSlide[1] = new AjaxControlToolkit.Slide("images/kyle.jpg", "kyle", "Kyle Broflovski");
            imgSlide[2] = new AjaxControlToolkit.Slide("images/kenny.jpg", "kenny", "Kenny McCormick");
            imgSlide[0] = new AjaxControlToolkit.Slide("images/stan.jpg", "stan", "Stan Marsh");
            imgSlide[3] = new AjaxControlToolkit.Slide("images/cartman.jpg", "cartman", "Eric Cartman");

            return (imgSlide);
        }


       
    }
}