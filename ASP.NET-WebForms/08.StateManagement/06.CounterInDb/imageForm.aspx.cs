using _06.Counter.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _05.ImageCounter
{
    public partial class imageForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CounterContext db = new CounterContext();
            var found = db.Visitors.FirstOrDefault();
            if (found == null)
            {
                db.Visitors.Add(new Visitor()
                {
                    Count = 1
                });
                db.SaveChanges();
                found = new Visitor()
                {
                    Count = 1
                };
            }
            else
            {
                found.Count++;
                db.SaveChanges();
            }


            Bitmap generatedImage = new Bitmap(110, 110);
            using (generatedImage)
            {
                Graphics gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    gr.FillRectangle(Brushes.MediumSeaGreen, 0, 0, 200, 200);

                    gr.DrawString(found.Count.ToString(),
                        new Font("Segoe UI", 25),
                        new SolidBrush(Color.BlanchedAlmond),
                         new PointF(35, 30));


                    // Set response header and write the image into response stream
                    Response.ContentType = "image/jpeg";

                    //Response.AppendHeader("Content-Disposition",
                    //    "attachment; filename=\"Financial-Report-April-2013.gif\"");

                    generatedImage.Save(Response.OutputStream, ImageFormat.Jpeg);
                }
            }

        }
    }
}