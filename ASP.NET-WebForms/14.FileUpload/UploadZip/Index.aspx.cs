using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UploadZip.Models;

namespace UploadZip
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            FileUploadContext db = new FileUploadContext();

            StringBuilder sb = new StringBuilder();
            foreach (var item in db.Files)
            {
                sb.AppendFormat("{0}. <br/>", item.Id);
                sb.AppendFormat("{0} <br/>", item.Content);
            }

            this.FileOutput = sb.ToString();
        }

        protected string FileOutput { get; set; }
    }
}