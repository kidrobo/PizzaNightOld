using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Helpers;

namespace PizzaNight
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] != null)
            {
                tbEmail.Text = Session["email"].ToString();
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            //Check for necessary info
            if (string.IsNullOrEmpty(tbPassword.Text) || string.IsNullOrEmpty(tbUsername.Text) || string.IsNullOrEmpty(tbEmail.Text))
            {
                LoginError.InnerText = "PLEASE FILL IN ALL INFO";
                LoginError.Visible = true;
                return;
            }

            if (tbPassword.Text == tbPasswordCheck.Text)
            {
                using (PizzaNightDataContext dc = new PizzaNightDataContext())
                {
                    if ((from t in dc.Users where t.Username.ToLower() == tbUsername.Text.ToLower() select t).Count() > 0)
                    {
                        LoginError.InnerText = "Username already in use. Try something a bit more original.";
                        LoginError.Visible = true;
                        return;
                    }

                    if ((from t in dc.Users where t.EmailAddress.ToLower() == tbEmail.Text.ToLower() select t).Count() > 0)
                    {
                        LoginError.InnerText = "Email already in use. Are you sure you haven't tried this before?";
                        LoginError.Visible = true;
                        return;
                    }

                    //Check to see if it is at least 8 characters
                    //if (tbPassword.Text.Length < 8)
                    //{
                    //    LoginError.InnerText = "Seriously? Less than 8 characters in your password? Try again";
                    //    LoginError.Visible = true;
                    //    return;
                    //}

                    var password = "";
                    var salt = "";
                    var hashedPassword = "";

                    password = tbPassword.Text;
                    salt = Crypto.GenerateSalt();
                    hashedPassword = Crypto.HashPassword(salt + password);


                    User newUser = new User()
                    {
                        ID           = Guid.NewGuid(),
                        Username     = tbUsername.Text,
                        Password     = hashedPassword,
                        Salt         = salt,
                        FirstName    = tbFistName.Text,
                        LastName     = tbLastName.Text,
                        EmailAddress = tbEmail.Text
                    };
                    dc.Users.InsertOnSubmit(newUser);
                    dc.SubmitChanges();

                    HttpRuntime.Cache["UserID"] = newUser.ID;
                    Response.Redirect("Deets");
                }
            }
            else
            {
                LoginError.InnerText = "PASSWORDS DO NOT MATCH. TRY HARDER.";
                LoginError.Visible = true;
            }
        }
    }
}