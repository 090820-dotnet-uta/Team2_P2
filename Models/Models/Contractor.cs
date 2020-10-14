using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    class Contractor
    {
        private int contractorId;
        private string username;
        private string firstName;
        private string lastName;
        private string description;
        private string email;
    //    private LoginInfo thisLoginInfo;

        public Contractor(string username, string firstName, string lastName, string description, string email)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            Email = email;
        }

        public int ContractorId { get => contractorId; set => contractorId = value; }
        public string Username { get => username; set => username = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Description { get => description; set => description = value; }
        public string Email { get => email; set => email = value; }
        //internal LoginInfo ThisLoginInfo { get => thisLoginInfo; set => thisLoginInfo = value; }
    }
}
