using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
   public class ProjectVM
    {
        private int projectId;
        private int clientId;
        private DateTime startDate;
        private DateTime endDate;
        private double paymentOffered;
        private string projectName;
        private Client thisClient;
   //     private List<Position> positions;

        public ProjectVM(int clientId, DateTime startDate, DateTime endDate, double paymentOffered, string projectName)
        {
            ClientId = clientId;
            StartDate = startDate;
            EndDate = endDate;
            PaymentOffered = paymentOffered;
            ProjectName = projectName;
        }  

        public int ProjectId { get => projectId; set => projectId = value; }
        public int ClientId { get => clientId; set => clientId = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public double PaymentOffered { get => paymentOffered; set => paymentOffered = value; }
        public string ProjectName { get => projectName; set => projectName = value; }
 //       internal Client ThisClient { get => thisClient; set => thisClient = value; }
    }
}
