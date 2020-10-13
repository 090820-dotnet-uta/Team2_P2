using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class LoginInfo
    {

        private int loginInfoId;
        private string username;
        private string password;

        public LoginInfo(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public int LoginInfoId { get => LoginInfoId; set => LoginInfoId = value; }

        [StringLength(40, MinimumLength = 2)]
        [Required]
        public string Username { get => Username; set => Username = value; }

        [StringLength(40, MinimumLength = 2)]
        [Required]
        public string Password { get => Password; set => Password = value; }

    }
}
