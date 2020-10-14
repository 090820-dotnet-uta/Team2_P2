using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    class Project
    {
        private int projectId;
        private int clientId;
        private DateTime startDate;
        private DateTime endDate;
        private double paymentOffered;
        private string projectName;
        private string description;
        private Client thisClient;

        public Project(int clientId, DateTime startDate, DateTime endDate, double paymentOffered, string projectName, string description)
        {
            ClientId = clientId;
            StartDate = startDate;
            EndDate = endDate;
            PaymentOffered = paymentOffered;
            ProjectName = projectName;
            Description = description;
        }

        public int ProjectId { get => projectId; set => projectId = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public double PaymentOffered { get => paymentOffered; set => paymentOffered = value; }
        public string ProjectName { get => projectName; set => projectName = value; }
        public string Description { get => description; set => description = value; }
        internal Client ThisClient { get => thisClient; set => thisClient = value; }
    }
}
