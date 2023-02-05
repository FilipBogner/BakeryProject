using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using NovProjekat.Models;
using System.Data.SqlClient;

namespace NovProjekat.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-Q5KDKVD\\SQLEXPRESS;Initial Catalog=NajboljaBaza;Integrated Security=True");
            con.Open();
            string upit = "SELECT Naziv, Lozinka From Klijenti";
            SqlCommand cmd = new SqlCommand(upit, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (Password.Text == reader[1].ToString())
                {
                    Label1.Text = "Your password is already in use";
                }
                else if (Email.Text == reader[0].ToString())
                {
                    Label1.Text = "Your name is already in use";
                }
            }
            if (Label1.Text=="")
            {
                SqlParameter p1 = new SqlParameter();
                SqlParameter p2 = new SqlParameter();
                p1.ParameterName = "Naziv";
                p2.ParameterName = "Lozinka";
                p1.Value =Email.Text;
                p2.Value =Password.Text;
                string upiti = "Insert into (Naziv,Lozinka)Klijenti Values(@Naziv,@Lozinka)";
                SqlCommand ccmd = new SqlCommand(upiti, con);
                ccmd.Parameters.Add(p1);
                ccmd.Parameters.Add(p2);
                ccmd.ExecuteNonQuery();



                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
                IdentityResult result = manager.Create(user, Password.Text);
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    //string code = manager.GenerateEmailConfirmationToken(user.Id);
                    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    ErrorMessage.Text = result.Errors.FirstOrDefault();
                }
            }
            con.Close();
        }
    }
}