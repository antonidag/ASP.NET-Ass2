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
                Response.Redirect("ErrorPage.aspx");
            else
                if(!IsPostBack)
                    UpdateDropList();
                
        }
        private void UpdateDropList()
        {
            if (Global.CurrentUser.Admin)
            {
                using (UserContext ctx = new UserContext())
                {
                    var users = ctx.Users.ToList();
                    droplist_users.DataSource = users;
                    droplist_users.DataTextField = "UserName";
                    droplist_users.DataValueField = "ID";
                    droplist_users.DataBind();
                }
            }
            else
            {
                using (UserContext ctx = new UserContext())
                {
                    var user = ctx.Users.ToList();
                    droplist_users.DataSource = user;
                    droplist_users.DataTextField = "UserName";
                    droplist_users.DataValueField = "ID";
                    droplist_users.DataBind();
                    droplist_users.SelectedValue = Global.CurrentUser.ID.ToString();
                    droplist_users.Enabled = false;
                }

            }

        }
        protected void btn_create_Click(object sender, EventArgs e)
        {
            string name = textbox_name.Text;
            string address = textbox_address.Text;
            string email = textbox_email.Text;
            string phone = textbox_phone.Text;
            int ID = int.Parse(droplist_users.SelectedValue);
            CreateContact(name, address, email, phone, ID);
            ClearTextBoxes();

        }
        private void ClearTextBoxes()
        {
            textbox_address.Text = "";
            textbox_email.Text = "";
            textbox_name.Text = "";
            textbox_phone.Text = "";
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