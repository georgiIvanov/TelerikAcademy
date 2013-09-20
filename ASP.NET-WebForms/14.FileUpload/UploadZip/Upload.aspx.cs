using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UploadZip.Models;

namespace UploadZip
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Expires = -1;
            try
            {
                HttpPostedFile file = Request.Files["uploaded"];

                ZipFile zipFile = ZipFile.Read(file.InputStream);
                StringBuilder zipContent = new StringBuilder();
                foreach (var zipEntry in zipFile.Entries)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    zipEntry.Extract(memoryStream);

                    memoryStream.Position = 0;
                    StreamReader reader = new StreamReader(memoryStream);
                    zipContent.AppendLine(reader.ReadToEnd());
                }

                FileUploadContext db = new FileUploadContext();
                db.Files.Add(new Models.File()
                {
                    Content = zipContent.ToString()
                });
                db.SaveChanges();


                Response.ContentType = "application/json";
                Response.Write("{}");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}