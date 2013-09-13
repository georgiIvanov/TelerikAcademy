using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTemplate.Models;

namespace WebFormsTemplate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Admin"))
            {
                Label1.Text = "Hello admin";

            }
            else if (User.IsInRole("Moderator"))
            {
                Label1.Text = "Hello mod";
            }
            else
            {
                Label1.Text = "Hello user!";
            }

            if (User.Identity.IsAuthenticated)
            {
                var tb = new TextBox();
                tb.ID = "tb_Insert";
                var submit = new Button();
                submit.ID = "btn_Submit";
                submit.Text = "Submit";
                submit.Click += submit_Click;
                InsertHolder.Controls.Add(tb);
                InsertHolder.Controls.Add(submit);
            }
        }


        void submit_Click(object sender, EventArgs e)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var tb = (TextBox)InsertHolder.FindControl("tb_Insert");

            

            var user = db.Users.Single(x => x.UserName == User.Identity.Name);

            if(!string.IsNullOrWhiteSpace(tb.Text))
            {
                db.Messages.Add(new Message()
                {
                    Text = tb.Text,
                    Author = user
                });
                db.SaveChanges();
                ChatView.DataBind();
                tb.Text = "";
            }
        }

        protected void ChatView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Button targetButton = (Button)e.Item.FindControl("EditButton");
            Button delete = (Button)e.Item.FindControl("DeleteButton");
            if (targetButton == null)
            {
                return;
            }

            if (!User.IsInRole("User") && User.Identity.IsAuthenticated)
            {
                targetButton.Enabled = true;
                if (User.IsInRole("Admin"))
                {
                    
                    delete.Enabled = true;
                }
                else
                {
                    delete.Enabled = false;
                }
            }
            else
            {
                targetButton.Enabled = false;
                delete.Enabled = false;
            }
        }

       
    }
}