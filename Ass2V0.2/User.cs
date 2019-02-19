using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ass2V0._2
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}