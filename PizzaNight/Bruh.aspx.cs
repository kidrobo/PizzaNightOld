using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaNight
{
    public partial class bruh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            using (PizzaNightDataContext dc = new PizzaNightDataContext())
            {
                if ((from t in dc.Users where t.EmailAddress.ToLower() == email.Text.ToLower() select t).Count() > 0)
                {
                    LoginError.InnerText = "Email already in use. Are you sure you haven't tried this before?";
                    LoginError.Visible = true;
                    return;
                }
                else
                {
                    Session["email"] = email.Text;
                    Response.Redirect("/SignUp");
                }
            }

                
        }
    }
}