using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FunnyNails.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool RegisterType { get; set; }

        public DateTime RegisterDate { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public DateTime BDay { get; set; }

        override public string Email { get; set; }

        public string Password { get; set; }
    }
}
