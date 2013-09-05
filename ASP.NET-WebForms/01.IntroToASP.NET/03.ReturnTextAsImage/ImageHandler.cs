using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Web;


namespace _03.ReturnTextAsImage
{
    public class ImageHandler : IHttpHandler
    {

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            var requestURL = context.Request.Url;

            var path = context.Server.MapPath("Data/blank.png");

            var bitmap = new Bitmap(path);


            var graphics = Graphics.FromImage(bitmap);
            var brush = new SolidBrush(Color.BlueViolet);
            graphics.FillRectangle(brush, 0, 0, 5000, 150);
            graphics.DrawString(
                context.Request.FilePath.Substring(1, context.Request.FilePath.Length - 5),
                new Font("Segoe UI", 25),
                new SolidBrush(Color.BlanchedAlmond),
                new PointF(25, 40));
            context.Response.ContentType = "image/png";
            bitmap.Save(context.Response.OutputStream, ImageFormat.Png);



        }
    }
}