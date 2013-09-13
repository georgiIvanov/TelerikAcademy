using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebFormsTemplate.Models;

namespace WebFormsTemplate.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            var db = new ApplicationDbContext();
            var manager = new AuthenticationIdentityManager(new IdentityStore(db));
            ApplicationUser u = new ApplicationUser()
            { 
                UserName = userName,
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text
            };

            

            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
            if (result.Success) 
            {
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);

                var foundRole = db.Roles.Single(x => x.Name == dl_Roles.SelectedValue);
                u.Roles = new System.Collections.Generic.HashSet<UserRole>();
                u.Roles.Add(new UserRole()
                {
                    Role = foundRole,
                    User = u
                });
                db.SaveChanges();
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}