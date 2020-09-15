using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckerApp.WebUI.Data
{
    public class User : IdentityUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
