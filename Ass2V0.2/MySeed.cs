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
                Password = "123"
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}