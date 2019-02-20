using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ass2V0._2
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumb { get; set; }
        public virtual User User { get; set; }
        public override string ToString()
        {
            return " Name:" +  Name + " Address: " + Address + " Phone: " + PhoneNumb + " Email: " + Email;
        }
    }
}