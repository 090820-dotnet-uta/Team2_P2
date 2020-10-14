using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Models.Models
{
    public class LoginInfo : IdentityUser
    {
        

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }

        

    
}
