using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ass2V0._2
{
    public class UserContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }

        public UserContext() : base("name=UserContext")
        {
            Database.SetInitializer<UserContext>(new MySeed());
        }
    }
}