using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ass2V0._2
{
    public partial class DisplayPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Global.CurrentUser == null)
                Response.Redirect("ErrorPage.aspx");
            else
                UserOrAdmin();

        }
        
        protected void btn_search_Click(object sender, EventArgs e)
        {
            string name = textbox_search.Text;
            int ID = Global.CurrentUser.ID;
            if (Global.CurrentUser.Admin)
                SearchAdmin(name);
            else
                Search(name, ID);

        }
        private void SearchAdmin(string name)
        {
            using (UserContext ctx = new UserContext())
            {
                listbox.Items.Clear();
                var contacts = ctx.Contacts.Where(c => c.Name.Contains(name)).ToList();
                listbox.DataSource = contacts;
                listbox.DataBind();
            }
        }
        private void Search(string name,int userID)
        {
            using (UserContext ctx = new UserContext())
            {
                listbox.Items.Clear();
                var contacts = ctx.Contacts.Where(c => c.User.ID == userID && c.Name.Contains(name)).ToList();
                listbox.DataSource = contacts;
                listbox.DataBind();
            }
        }
        private void UserOrAdmin()
        {
            listbox.Items.Clear();
            if (Global.CurrentUser.Admin)
            {
                using (UserContext ctx = new UserContext())
                {
                    var allContacts = ctx.Contacts.ToList();
                    listbox.DataSource = allContacts;
                    listbox.DataBind();
                }
            }
            else
            {
                using (UserContext ctx = new UserContext())
                {
                    int ID = Global.CurrentUser.ID;
                    var allContacts = ctx.Contacts;
                    var contacts = allContacts.Where(c => c.User.ID == ID).ToList();
                    listbox.DataSource = contacts;
                    listbox.DataBind();
                }
            }
        }
    }
}