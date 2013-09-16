using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.AjaxUpdate
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            GridView gv = (GridView)sender;
            var value = Convert.ToInt32(gv.SelectedValue);
            NorthwindEntities db = new NorthwindEntities();
            OrdersGridView.DataSource = db.Orders.Where(x => x.EmployeeID == value)
                .ToList();
            OrdersGridView.DataBind();
        }
    }
}