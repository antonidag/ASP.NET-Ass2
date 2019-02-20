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
            if (!IsPostBack)
            {
                List<ListItem> list = new List<ListItem>();
                int ID = 1;
                using (UserContext ctx = new UserContext())
                {
                    var allContacts = ctx.Contacts;
                    var contacts = allContacts.Where(c => c.User.ID == ID).ToList();
                    int i = 0;
                    foreach (var c in contacts)
                    {
                        ListItem item = new ListItem();
                        item.Text = "ID: " + ID + c.ToString();
                        item.Value = i.ToString();
                        list.Add(item);
                        i++;
                    }
                    listbox.DataSource = list;
                    listbox.DataBind();
                }
            }
            
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            var index = listbox.SelectedIndex;
            Contact contact = GetContact(index);
            textbox_address.Text = contact.Address;
            textbox_email.Text = contact.Email;
            textbox_name.Text = contact.Name;
            textbox_phone.Text = contact.PhoneNumb;

        }
        private Contact GetContact(int index)
        {
            int ID = 1;
            using (UserContext ctx = new UserContext())
            {
                var contact = ctx.Contacts.Where(c => c.ID == index + 1 && c.User.ID == ID).ToList();
                return contact[0];
            }
        }
    }
}