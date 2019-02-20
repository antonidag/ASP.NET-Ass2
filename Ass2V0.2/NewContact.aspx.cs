using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ass2V0._2
{
    public partial class NewContact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Global.CurrentUser == null)
                Response.Write("Login in first");
                
        }

        protected void btn_create_Click(object sender, EventArgs e)
        {
            string name = textbox_name.Text;
            string address = textbox_address.Text;
            string email = textbox_email.Text;
            string phone = textbox_phone.Text;
            CreateContact(name, address, email, phone, Global.CurrentUser.ID);

        }
        private void CreateContact(string name, string address,string email, string phone, int userID)
        {
            using (UserContext ctx = new UserContext())
            {
                ctx.Contacts.Add(new Contact()
                {
                    Address = address,
                    Email = email,
                    Name = name,
                    PhoneNumb = phone,
                    User = ctx.Users.Find(userID)
                });
                ctx.SaveChanges();
            }
        }
    }
}