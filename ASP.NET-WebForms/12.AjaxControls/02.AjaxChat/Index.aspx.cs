using _02.AjaxChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _02.AjaxChat
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ChatContext db = new ChatContext();
            ChatListView.DataSource = db.Messages.ToList();
            ChatListView.DataBind();
            if (ViewState["username"] != null)
            {
                ((TextBox)Page.FindControl("tb_Username")).Text = (string)ViewState["username"];
            }
            ((TextBox)Page.FindControl("tb_Message")).Text = "";
        }

        protected void InsertButton_Command(object sender, CommandEventArgs e)
        {
            var tbUsername = ((TextBox)Page.FindControl("tb_Username"));
            if(string.IsNullOrWhiteSpace(tbUsername.Text)){
                return ;
            }
            ViewState["username"] = tbUsername.Text;

            string username = tbUsername.Text;
            string text = ((TextBox)Page.FindControl("tb_Message")).Text;
            ChatContext db = new ChatContext();
            db.Messages.Add(new Message()
            {
                Username = username,
                Text = text
            });

            db.SaveChanges();

        }

        protected void ChatListView_ItemInserting(object sender, ListViewInsertEventArgs e)
        {

        }

    }
}