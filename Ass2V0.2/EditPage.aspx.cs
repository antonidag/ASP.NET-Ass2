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
                UpdateListBox();
            }
            
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            Contact contact = GetContact(int.Parse(listbox.SelectedItem.Value));
            textbox_address.Text = contact.Address;
            textbox_email.Text = contact.Email;
            textbox_name.Text = contact.Name;
            textbox_phone.Text = contact.PhoneNumb;
            textbox_contactID.Text = contact.ID.ToString();


        }
        private Contact GetContact(int contactID)
        {
            using (UserContext ctx = new UserContext())
            {
                var contact = ctx.Contacts.Find(contactID);
                return contact;
            }
        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {


            string name = textbox_name.Text;
            string email = textbox_email.Text;
            string phone = textbox_phone.Text;
            string address = textbox_address.Text;
            int contactID = int.Parse(textbox_contactID.Text);

            using (UserContext ctx = new UserContext())
            {
                ctx.Contacts.Find(contactID).Name = name;
                ctx.Contacts.Find(contactID).Email = email;
                ctx.Contacts.Find(contactID).PhoneNumb = phone;
                ctx.Contacts.Find(contactID).Address = address;
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
            textbox_contactID.Text = "";
        }
        private void UpdateListBox()
        {
            listbox.Items.Clear();
            int ID = 1; // Ändra detta till Global.Cunnrent.ID
            using (UserContext ctx = new UserContext())
            {
                var allContacts = ctx.Contacts;
                var contacts = allContacts.Where(c => c.User.ID == ID).ToList();
                listbox.DataSource = contacts;
                listbox.DataTextField = "Info";
                listbox.DataValueField = "ID";
                listbox.DataBind();
            }
        }

        protected void btn_Remove_Click(object sender, EventArgs e)
        {
            int contactID = int.Parse(listbox.SelectedItem.Value);
            using (UserContext ctx = new UserContext())
            {
                ctx.Contacts.Remove(ctx.Contacts.Find(contactID));
                ctx.SaveChanges();
            }
            ClearTextBoxes();
            UpdateListBox();
        }
    }
}