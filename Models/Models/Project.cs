using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
   public class Project
    {
        private int projectId;
        private string userId;
        private DateTime startDate;
        private DateTime endDate;
        private double paymentOffered;
        private string projectName;
        private LoginInfo thisUser;
        private string description;

        public Project( string userId, DateTime startDate, DateTime endDate, double paymentOffered, string projectName, string description)
        {
            UserId = userId;
            StartDate = startDate;
            EndDate = endDate;
            PaymentOffered = paymentOffered;
            ProjectName = projectName;
            Description = description;
        }

        public int ProjectId { get => projectId; set => projectId = value; }
        public string UserId { get => userId; set => userId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public double PaymentOffered { get => paymentOffered; set => paymentOffered = value; }
        public string ProjectName { get => projectName; set => projectName = value; }
        internal LoginInfo ThisUser { get => thisUser; set => thisUser = value; }

        public string Description { get => description; set => description = value; }
    }
}
