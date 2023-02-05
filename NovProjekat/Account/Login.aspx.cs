using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using NovProjekat.Models;
using System.Data.SqlClient;

namespace NovProjekat.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
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
                    if (Email.Text == reader[0].ToString())
                    {
                        if (IsValid)
                        {
                            // Validate the user password
                            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                            var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                            // This doen't count login failures towards account lockout
                            // To enable password failures to trigger lockout, change to shouldLockout: true
                            var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

                            switch (result)
                            {
                                case SignInStatus.Success:
                                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                                    break;
                                case SignInStatus.LockedOut:
                                    Response.Redirect("/Account/Lockout");
                                    break;
                                case SignInStatus.RequiresVerification:
                                    Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                                    Request.QueryString["ReturnUrl"],
                                                                    RememberMe.Checked),
                                                      true);
                                    break;
                                case SignInStatus.Failure:
                                default:
                                    FailureText.Text = "Invalid login attempt";
                                    ErrorMessage.Visible = true;
                                    break;
                            }
                        }
                        Label1.Text = "";
                    }
                    else
                    {
                        Label1.Text = "Please enter a valid username";
                    }
                }
                else
                {
                    Label1.Text = "Please enter a valid password";
                }
            }
        }
    }
}