using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ass2V0._2
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (UserContext ctx = new UserContext())
            {
                var user = ctx.Users.First();
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string username = textbox_username.Text;
            string password = textbox_password.Text;

            using (UserContext ctx = new UserContext())
            {
                var user = ctx.Users.ToList().Find( (u) => u.UserName == username && u.Password == password);
                if (user != null)
                    Response.Redirect("DisplayPage.aspx");
            }
        }
    }
}