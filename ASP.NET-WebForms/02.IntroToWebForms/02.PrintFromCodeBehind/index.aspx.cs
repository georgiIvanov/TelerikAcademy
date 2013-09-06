using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.PrintFromCodeBehind
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var text = "<h1>Hello, from Code Behind!</h1>";

            byte[] bytes = Encoding.UTF8.GetBytes(text);

            Context.Response.OutputStream.Write(bytes, 0, bytes.Length);

            var asm = Assembly.GetExecutingAssembly();

            var info = string.Format("{0} <br/> {1}", asm.FullName, asm.Location);

            displayInfo.InnerHtml = info;

        }
    }
}