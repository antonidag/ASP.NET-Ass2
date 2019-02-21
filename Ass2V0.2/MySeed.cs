using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ass2V0._2
{
    public class MySeed : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            context.Users.Add(new User()
            {
                UserName = "Anton",
                Password = "123",
                Admin = true
            });
            context.SaveChanges();
            context.Users.Add(new User()
            {
                UserName = "Karl",
                Password = "123",
                Admin = false
            });
            context.SaveChanges();
            context.Contacts.Add(new Contact()
            {
                Address = "Genarp",
                Name = "Kalle Andersson",
                Email = "kalle@outlook.com",
                PhoneNumb = "070-123-456",
                User = context.Users.Find(1)
            });
            context.SaveChanges();
            context.Contacts.Add(new Contact()
            {
                Address = "Sodra Sandby",
                Name = "Tobias Ekdal",
                Email = "tobias@outlook.com",
                PhoneNumb = "070-321-654",
                User = context.Users.Find(1)
            });
            context.SaveChanges();
            context.Contacts.Add(new Contact()
            {
                Address = "Bjerred",
                Name = "Aatu Karrenen",
                Email = "atu@outlook.com",
                PhoneNumb = "070-321-654",
                User = context.Users.Find(1)
            });
            context.SaveChanges();
            context.Contacts.Add(new Contact()
            {
                Address = "Bjerred",
                Name = "Max Nyberg",
                Email = "max@outlook.com",
                PhoneNumb = "070-978-654",
                User = context.Users.Find(2)
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}