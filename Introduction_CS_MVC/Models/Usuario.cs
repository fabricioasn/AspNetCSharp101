using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Introduction_CS_MVC.Models
{
    public class Usuario
    {
        public string Name { get; set; }
        public string Observ { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string pswd { get; set; }
        public string pswdconfirm { get; set; }

        public static implicit operator Var(Usuario v)
        {
            throw new NotImplementedException();
        }
    }
}