using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Models.Models
{
    public class HireRequest
    {
        private int hireRequestId;
        private int positionId;
        private string clientId;
        private string contractorId;
        private string requestStatus;
        private Position thisPosition;

        public HireRequest(int positionId, string clientId, string contractorId)
        {
            PositionId = positionId;
            ClientId = clientId;
            ContractorId = contractorId;
            ContractorId = "pending";
        }

        public int HireRequestId { get => hireRequestId; set => hireRequestId = value; }
        public int PositionId { get => positionId; set => positionId = value; }
        public string ClientId { get => clientId; set => clientId = value; }
        public string ContractorId { get => contractorId; set => contractorId = value; }
        public string RequestStatus { get => requestStatus; set => requestStatus = value; }
        public virtual LoginInfo ThisClient { get; set; }
        public virtual LoginInfo ThisContractor { get; set; }
        internal Position ThisPosition { get => thisPosition; set => thisPosition = value; }
    }
}
