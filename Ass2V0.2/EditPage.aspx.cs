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

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            var index = listbox.SelectedIndex + 1;
            string name = textbox_name.Text;
            string email = textbox_email.Text;
            string phone = textbox_phone.Text;
            string address = textbox_address.Text;
            using (UserContext ctx = new UserContext())
            {
                ctx.Contacts.Find(index).Name = name;
                ctx.Contacts.Find(index).Email = email;
                ctx.Contacts.Find(index).PhoneNumb = phone;
                ctx.Contacts.Find(index).Address = address;
                ctx.SaveChanges();

            }
            UpdateListBox();
            ClearTextBoxes();
        }
        private void ClearTextBoxes()
        {
            textbox_address.Text = "";
            textbox_email.Text = "";
            textbox_name.Text = "";
            textbox_phone.Text = "";
        }
        private void UpdateListBox()
        {
            listbox.Items.Clear();
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
}