using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ass2V0._2
{
    public partial class EditPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ListItem> list = new List<ListItem>();
            int ID = 1;
            using (UserContext ctx = new UserContext())
            {
                var allContacts = ctx.Contacts;
                var contacts = allContacts.Where(c => c.User.ID == ID).ToList();
                foreach (var c in contacts)
                {
                    ListItem item = new ListItem();
                    item.Text = "ID: " + ID + c.ToString();
                    list.Add(item);
                }
                listbox.DataSource = list;
                listbox.DataBind();
            }
        }
    }
}